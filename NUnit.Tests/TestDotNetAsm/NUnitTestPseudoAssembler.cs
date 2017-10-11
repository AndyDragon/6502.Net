﻿using DotNetAsm;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests.TestDotNetAsm
{
    internal     /// <summary>
        /// barebones assembly controller
        /// </summary>
    class TestController : IAssemblyController
    {
        public TestController() :
            this(null)
        {

        }

        public TestController(string[] args) :
            base()
        {
            Output = new Compilation(true);

            Options = new AsmCommandLineOptions();

            Log = new ErrorLog();

            Evaluator = new Evaluator(@"\$([a-fA-F0-9]+)");

            Encoding = new AsmEncoding();

            Evaluator.DefineSymbolLookup(@"(?<=\B)'(.)'(?=\B)", (chr) =>
                Encoding.GetTranslation(chr.Trim('\'').First()).ToString());
            
            Labels = new Dictionary<string, string>();

            if (args != null)
                Options.ProcessArgs(args);
        }

        public void Assemble()
        {

        }

        public AsmCommandLineOptions Options
        {
            get;
            private set;
        }

        public string GetNearestScope(string token, string scope)
        {
            return string.Empty;
        }

        public string GetScopedLabelValue(string label, SourceLine line)
        {
            if (Labels.ContainsKey(label))
                return Labels[label];
            return string.Empty;
        }

        public bool TerminateAssembly(SourceLine line)
        {
            throw new NotImplementedException();
        }

        public Compilation Output
        {
            get;
            private set;
        }

        public ErrorLog Log
        {
            get;
            private set;
        }

        public IDictionary<string, string> Labels
        {
            get;
            private set;
        }

        public AsmEncoding Encoding
        {
            get;
            private set;
        }

        public IEvaluator Evaluator
        {
            get;
            private set;
        }

        public void AddAssembler(ILineAssembler asm)
        {
            throw new NotImplementedException();
        }

        public void AddSymbol(string symbol)
        {
            throw new NotImplementedException();
        }

        public Action<IAssemblyController, BinaryWriter> HeaderOutputAction { get; set; }

        public Action<IAssemblyController, BinaryWriter> FooterOutputAction { get; set; }

        public string BannerText { get; set; }

        public string VerboseBannerText { get; set; }

        public ILineDisassembler Disassembler { get; set; }
    }

    [TestFixture]
    public class NUnitTestPseudoAssembler : NUnitAsmTestBase
    {
        public NUnitTestPseudoAssembler()
        {
            Controller = new TestController();
            LineAssembler = new PseudoAssembler(Controller);
        }
        [Test]
        public void TestMultiByte()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".byte";
            line.Operand = "$01,$02 , $03, $04, $05";
            TestInstruction(line, 0x0005, 5, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 });

            line.Instruction = ".word";
            line.Operand = "$01,$02, $1234 , $ffff, $7323";
            TestInstruction(line, 0x000a, 10, new byte[] { 0x01, 0x00, 0x02, 0x00, 0x34, 0x12,
                                                           0xff, 0xff, 0x23, 0x73});

            line.Instruction = ".lint";
            line.Operand = "78332, ?, -33000";
            TestInstruction(line, 0x0009, 9, new byte[] { 0xfc, 0x31, 0x01,
                                                          0x00, 0x00, 0x00,
                                                          0x18, 0x7f, 0xff});

            line.Instruction = ".dword";
            line.Operand = "1,2,3,$ffd2";
            TestInstruction(line, 0x0010, 16, new byte[] { 0x01, 0x00, 0x00, 0x00,
                                                           0x02, 0x00, 0x00, 0x00,
                                                           0x03, 0x00, 0x00, 0x00,
                                                           0xd2, 0xff, 0x00, 0x00});

            line.Instruction = ".dint";
            line.Operand = "? , ?,? ,?";
            TestInstruction(line, 0x0010, 16, null);
        }

        [Test]
        public void TestByteChar()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".byte";
            line.Operand = "0,255";
            TestInstruction(line, 0x0002, 2, new byte[] { 0x00, 0xff });

            line.Operand = "-123";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".char";
            line.Operand = "-128,127";
            TestInstruction(line, 0x0002, 2, new byte[] { 0x80, 0x7f });

            line.Operand = "192";
            TestForFailure<OverflowException>(line);
        }

        [Test]
        public void TestWordSint()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".sint";
            line.Operand = "-32768,32767";
            TestInstruction(line, 0x0004, 4, new byte[] { 0x00, 0x80, 0xff, 0x7f });

            line.Operand = "$ffd2";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".word";
            TestInstruction(line, 0x0002, 2, new byte[] { 0xd2, 0xff });

            line.Operand = "-1";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".addr";
            TestForFailure<OverflowException>(line);

            line.Operand = "65232 , $c000";
            TestInstruction(line, 0x0004, 4, new byte[] { 0xd0, 0xfe, 0x00, 0xc0 });

            line.Operand = "$010000";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".word";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".sint";
            TestForFailure<OverflowException>(line);
        }

        [Test]
        public void TestDwordDint()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".dint";
            line.Operand = int.MinValue.ToString() + ", " + int.MaxValue.ToString();
            TestInstruction(line, 0x0008, 8, new byte[] { 0x00, 0x00, 0x00, 0x80, 
                                                          0xff, 0xff, 0xff, 0x7f});
            line.Operand = uint.MaxValue.ToString();
            TestForFailure<OverflowException>(line);

            line.Instruction = ".dword";
            TestInstruction(line, 0x0004, 4, new byte[] { 0xff, 0xff, 0xff, 0xff });

            line.Operand = "-32342";
            TestForFailure<OverflowException>(line);
        }

        [Test]
        public void TestLintLong()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".lint";
            line.Operand = Int24.MinValue.ToString() + " , " + Int24.MaxValue.ToString();
            TestInstruction(line, 0x0006, 6, new byte[] { 0x00, 0x00, 0x80, 
                                                          0xff, 0xff, 0x7f});

            line.Operand = "16777215";
            TestForFailure<OverflowException>(line);

            line.Instruction = ".long";
            TestInstruction(line, 0x0003, 3, new byte[] { 0xff, 0xff, 0xff });

            line.Operand = "$01000000";
            TestForFailure<OverflowException>(line);
        }

        [Test]
        public void TestStringFormats()
        {
            string teststring = "HELLO, WORLD";
            var ascbytes = Encoding.ASCII.GetBytes(teststring);

            List<byte> test = new List<byte>();

            SourceLine line = new SourceLine();

            test.Add(0x0c);
            test.AddRange(ascbytes);
            test.AddRange(BitConverter.GetBytes(0xffd2).Take(2));

            line.Instruction = ".string";
            line.Operand = string.Format("12, \"{0}\", $ffd2", teststring);
            TestInstruction(line, 0x000f, 15, test);

            test.Clear();
            test.AddRange(BitConverter.GetBytes(-32768).Take(2));
            test.Add(0x0d);
            test.AddRange(ascbytes);
            test.Add(0);

            line.Instruction = ".cstring";
            line.Operand = string.Format("-32768, 13, \"{0}\"", teststring);
            TestInstruction(line, test.Count, test.Count, test);

            test.Clear();
            test.Add(Convert.ToByte(ascbytes.Count() + 2));
            test.AddRange(ascbytes);

            int instructionsize = 1     // total operand size byte
                                  + ascbytes.Count() // string size
                                  + 2;  // two uninitialized bytes


            line.Instruction = ".pstring";
            line.Operand = string.Format("\"{0}\", ?, ?", teststring);
            TestInstruction(line, instructionsize, instructionsize, test);

            test.Clear();
            test.Add(42);
            test.Add(0);
            test.Add(0);
            test.AddRange(ascbytes);
            test[test.Count - 1] |= 0x80;

            line.Instruction = ".nstring";
            line.Operand = string.Format("42, ?, ?, \"{0}\"", teststring);
            TestInstruction(line, test.Count(), test.Count(), test);

            line.Operand = line.Operand + "$80";
            TestForFailure<ExpressionException>(line);

            line.Operand = string.Format("42, ?, ?, \"{0}\", $80", teststring);
            TestForFailure<OverflowException>(line);

            test.Clear();
            test.AddRange(BitConverter.GetBytes(0x0d0d).Take(2));
            test.AddRange(ascbytes);
            test = test.Select(b => { b <<= 1; return b; }).ToList();
            test[test.Count - 1] += 1;

            Assert.IsTrue(Controller.Output.GetCompilation().Count == 0);

            line.Instruction = ".lsstring";
            line.Operand = string.Format("$0d0d, \"{0}\"", teststring);
            TestInstruction(line, test.Count(), test.Count(), test);

            line.Operand += ",$80";
            TestForFailure<OverflowException>(line);
        }

        [Test]
        public void TestEncodingDefine()
        {
            SourceLine line = new SourceLine();
            
            line.Instruction = ".encoding";
            line.Operand = "test";
            LineAssembler.AssembleLine(line);

            line.Instruction = ".map";
            line.Operand = "\"A\", \"a\"";
            LineAssembler.AssembleLine(line);

            char translated = (char)Controller.Encoding.GetTranslation('A');
            Assert.AreEqual('a', translated);

            line.Instruction = ".byte";
            line.Operand = "'A'";
            TestInstruction(line, 0x0001, 1, new byte[] { (byte)'a' });

            line.Instruction = ".unmap";
            line.Operand = "$41";
            LineAssembler.AssembleLine(line);

            line.Instruction = ".byte";
            line.Operand = "'A'";
            TestInstruction(line, 0x0001, 1, new byte[] { (byte)'A' });

            line.Instruction = ".encoding";
            line.Operand = "none";
            LineAssembler.AssembleLine(line);

            translated = (char)Controller.Encoding.GetTranslation('A');
            Assert.AreEqual('A', translated);

            line.Instruction = ".byte";
            line.Operand = "'A'";
            TestInstruction(line, 0x0001, 1, new byte[] { (byte)'A' });

            line.Instruction = ".encoding";
            line.Operand = "test";
            LineAssembler.AssembleLine(line);

            line.Instruction = ".map";
            line.Operand = "\"az\", \"A\"";
            LineAssembler.AssembleLine(line);

            string test = "hello reality";
            line.Instruction = ".string";
            line.Operand = string.Format("\"{0}\"", test);
            TestInstruction(line, test.Length, test.Length, Encoding.UTF8.GetBytes(test.ToUpper()));

            line.Instruction = ".unmap";
            line.Operand = "\"az\"";
            LineAssembler.AssembleLine(line);

            line.Instruction = ".string";
            line.Operand = string.Format("\"{0}\"", test);
            TestInstruction(line, test.Length, test.Length, Encoding.UTF8.GetBytes(test));

            line.Instruction = ".map";
            line.Operand = "$80, $ff, '\0'";
            LineAssembler.AssembleLine(line);

            translated = (char)Controller.Encoding.GetTranslation('\xc1');
            Assert.AreEqual('A', translated);

            line.Instruction = ".map";
            line.Operand = "\"π\", $5e";
            LineAssembler.AssembleLine(line);

            line.Instruction = ".byte";
            line.Operand = "'π'";
            TestInstruction(line, 0x0001, 0x0001, new byte[] { (byte)'^' });
        }

        [Test]
        public void TestFill()
        {
            SourceLine line = new SourceLine();

            line.Instruction = ".byte";
            line.Operand = "0";
            LineAssembler.AssembleLine(line);
            Assert.IsFalse(Controller.Log.HasErrors);
            Assert.AreEqual(0x0001, Controller.Output.LogicalPC);
            Assert.IsTrue(Controller.Output.GetCompilation().Count == 1);

            // test uninitialized
            line.Instruction = ".fill";
            line.Operand = "10";
            TestInstruction(line, 0x000b, 10, new byte[] { 0x00 });

            // test uninitialized another way
            line.Operand = "10, ?";
            TestInstruction(line, 0x000a, 10, null);

            // test fill bytes
            line.Operand = "10, $ea";
            TestInstruction(line, 0x000a, 10, new byte[] { 0xea, 0xea, 0xea, 0xea, 0xea,
                                                           0xea, 0xea, 0xea, 0xea, 0xea});

            line.Operand = string.Empty;
            TestForFailure<InvalidOperationException>(line);
            
            line.Operand = "10, $ea, $20";
            TestForFailure(line);

        }

        [Test]
        public void TestAlign()
        {
            SourceLine line = new SourceLine();

            line.Instruction = ".byte";
            line.Operand = "0";
            line.PC = 1;
            LineAssembler.AssembleLine(line);
            Assert.IsFalse(Controller.Log.HasErrors);
            Assert.AreEqual(0x0001, Controller.Output.LogicalPC);
            Assert.IsTrue(Controller.Output.GetCompilation().Count == 1);

            // align to nearest page, uninitialized
            line.Instruction = ".align";
            line.Operand = "$100";
            TestInstruction(line, 0x0100, 255, new byte[] { 0x00 });

            // align to nearest page, uninitialized
            Controller.Output.SetPC(1);
            line.PC = 1;
            line.Operand = "$100, ?";
            TestInstruction(line, 0x0100, 255, null);

            // align to nearest 0x10, filled
            Controller.Output.SetPC(0x0006);
            line.PC = 0x0006;
            line.Operand = "$10, $ea";
            TestInstruction(line, 0x0010, 10, new byte[] { 0xea, 0xea, 0xea, 0xea, 0xea,
                                                           0xea, 0xea, 0xea, 0xea, 0xea});


            line.Operand = string.Empty;
            TestForFailure<InvalidOperationException>(line);
           
            line.Operand = "$100, $10, $02";
            TestForFailure(line);
        }

        [Test]
        public void TestSyntaxErrors()
        {
            SourceLine line = new SourceLine();
            line.Instruction = ".byte";
            line.Operand = "3,";
            TestForFailure<ExpressionException>(line);

            line.Operand = "3,,2";
            TestForFailure<ExpressionException>(line);

            line.Operand = "pow(3,2)";
            TestInstruction(line, 0x0001, 1, new byte[] { 0x09 });

            line.Instruction = ".char";
            line.Operand = "%34";
            TestForFailure<ExpressionException>(line);

            line.Operand = "256%34";
            TestInstruction(line, 0x0001, 1, new byte[] { 0x12 });

            line.Operand = "%0101";
            TestInstruction(line, 0x0001, 1, new byte[] { 0x05 });

            line.Operand = "'";
            TestForFailure<SourceLine.QuoteNotEnclosedException>(line);

            line.Operand = "-?";
            TestForFailure<ExpressionException>(line);
            
            line.Operand = "-1,?";
            TestInstruction(line, 0x0002, 2, new byte[] { 0xff });

            line.Instruction = ".string";
            line.Operand = "\"hello, \",\"world";
            TestForFailure<SourceLine.QuoteNotEnclosedException>(line);

            line.Operand = "\"'''\"";
            TestInstruction(line, 0x0003, 3, new byte[] { 0x27, 0x27, 0x27 });
        }
    }
}
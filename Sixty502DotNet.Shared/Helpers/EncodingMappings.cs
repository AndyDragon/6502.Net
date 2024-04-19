//-----------------------------------------------------------------------------
// Copyright (c) 2017-2024 informedcitizenry <informedcitizenry@gmail.com>
//
// Licensed under the MIT license. See LICENSE for full license information.
// 
//-----------------------------------------------------------------------------

using Sixty502DotNet.Shared;

public static class EncodingMappings
{
    /// <summary>
    /// Map the control codes and encodings for several 8-bit platforms,
    /// such as Commodore screen codes, PETSCII, and Atari.
    /// </summary>
    /// <param name="encoding">The <see cref="AsmEncoding"/> to map the encodings.</param>
    public static void MapEncodings(AsmEncoding encoding)
    {
        encoding.SelectEncoding("\"petscii\"");
        encoding.Map("az", 'A');
        encoding.Map("AZ", 0xc1);
        encoding.Map('£', '\\');
        encoding.Map('↑', '^');
        encoding.Map('←', '_');
        encoding.Map('▌', 0xa1);
        encoding.Map('▄', 0xa2);
        encoding.Map('▔', 0xa3);
        encoding.Map('▁', 0xa4);
        encoding.Map('▏', 0xa5);
        encoding.Map('▒', 0xa6);
        encoding.Map('▕', 0xa7);
        encoding.Map('◤', 0xa9);
        encoding.Map('├', 0xab);
        encoding.Map('└', 0xad);
        encoding.Map('┐', 0xae);
        encoding.Map('▂', 0xaf);
        encoding.Map('┌', 0xb0);
        encoding.Map('┴', 0xb1);
        encoding.Map('┬', 0xb2);
        encoding.Map('┤', 0xb3);
        encoding.Map('▎', 0xb4);
        encoding.Map('▍', 0xb5);
        encoding.Map('▃', 0xb9);
        encoding.Map('✓', 0xba);
        encoding.Map('┘', 0xbd);
        encoding.Map('━', 0xc0);
        encoding.Map('♠', 0xc1);
        encoding.Map('│', 0xc2);
        encoding.Map('╮', 0xc9);
        encoding.Map('╰', 0xca);
        encoding.Map('╯', 0xcb);
        encoding.Map('╲', 0xcd);
        encoding.Map('╱', 0xce);
        encoding.Map('●', 0xd1);
        encoding.Map('♥', 0xd3);
        encoding.Map('╭', 0xd5);
        encoding.Map('╳', 0xd6);
        encoding.Map('○', 0xd7);
        encoding.Map('♣', 0xd8);
        encoding.Map('♦', 0xda);
        encoding.Map('┼', 0xdb);
        encoding.Map('π', 0xde);
        encoding.Map('◥', 0xdf);
        encoding.Map("\x80\xff", 0x80);

        encoding.MapControlCode("{BELL}", 0x07 );
        encoding.MapControlCode("{BLACK}", 0x90 );
        encoding.MapControlCode("{BLK}", 0x90 );
        encoding.MapControlCode("{BLUE}", 0x1F );
        encoding.MapControlCode("{BLU}", 0x1F );
        encoding.MapControlCode("{BRN}", 0x95 );
        encoding.MapControlCode("{BROWN}", 0x95 );
        encoding.MapControlCode("{CBM-*}", 0xDF );
        encoding.MapControlCode("{CBM-+}", 0xA6 );
        encoding.MapControlCode("{CBM--}", 0xDC );
        encoding.MapControlCode("{CBM-0}", 0x30 );
        encoding.MapControlCode("{CBM-1}", 0x81 );
        encoding.MapControlCode("{CBM-2}", 0x95 );
        encoding.MapControlCode("{CBM-3}", 0x96 );
        encoding.MapControlCode("{CBM-4}", 0x97 );
        encoding.MapControlCode("{CBM-5}", 0x98 );
        encoding.MapControlCode("{CBM-6}", 0x99 );
        encoding.MapControlCode("{CBM-7}", 0x9A );
        encoding.MapControlCode("{CBM-8}", 0x9B );
        encoding.MapControlCode("{CBM-9}", 0x29 );
        encoding.MapControlCode("{CBM-@}", 0xA4 );
        encoding.MapControlCode("{CBM-^}", 0xDE );
        encoding.MapControlCode("{CBM-A}", 0xB0 );
        encoding.MapControlCode("{CBM-B}", 0xBF );
        encoding.MapControlCode("{CBM-C}", 0xBC );
        encoding.MapControlCode("{CBM-D}", 0xAC );
        encoding.MapControlCode("{CBM-E}", 0xB1 );
        encoding.MapControlCode("{CBM-F}", 0xBB );
        encoding.MapControlCode("{CBM-G}", 0xA5 );
        encoding.MapControlCode("{CBM-H}", 0xB4 );
        encoding.MapControlCode("{CBM-I}", 0xA2 );
        encoding.MapControlCode("{CBM-J}", 0xB5 );
        encoding.MapControlCode("{CBM-K}", 0xA1 );
        encoding.MapControlCode("{CBM-L}", 0xB6 );
        encoding.MapControlCode("{CBM-M}", 0xA7 );
        encoding.MapControlCode("{CBM-N}", 0xAA );
        encoding.MapControlCode("{CBM-O}", 0xB9 );
        encoding.MapControlCode("{CBM-POUND}", 0xA8 );
        encoding.MapControlCode("{CBM-P}", 0xAF );
        encoding.MapControlCode("{CBM-Q}", 0xAB );
        encoding.MapControlCode("{CBM-R}", 0xB2 );
        encoding.MapControlCode("{CBM-S}", 0xAE );
        encoding.MapControlCode("{CBM-T}", 0xA3 );
        encoding.MapControlCode("{CBM-UP ARROW}", 0xDE );
        encoding.MapControlCode("{CBM-U}", 0xB8 );
        encoding.MapControlCode("{CBM-V}", 0xBE );
        encoding.MapControlCode("{CBM-W}", 0xB3 );
        encoding.MapControlCode("{CBM-X}", 0xBD );
        encoding.MapControlCode("{CBM-Y}", 0xB7 );
        encoding.MapControlCode("{CBM-Z}", 0xAD );
        encoding.MapControlCode("{CLEAR}", 0x93 );
        encoding.MapControlCode("{CLR}", 0x93 );
        encoding.MapControlCode("{CONTROL-0}", 0x92 );
        encoding.MapControlCode("{CONTROL-1}", 0x90 );
        encoding.MapControlCode("{CONTROL-2}", 0x05 );
        encoding.MapControlCode("{CONTROL-3}", 0x1C );
        encoding.MapControlCode("{CONTROL-4}", 0x9F );
        encoding.MapControlCode("{CONTROL-5}", 0x9C );
        encoding.MapControlCode("{CONTROL-6}", 0x1E );
        encoding.MapControlCode("{CONTROL-7}", 0x1F );
        encoding.MapControlCode("{CONTROL-8}", 0x9E );
        encoding.MapControlCode("{CONTROL-9}", 0x12 );
        encoding.MapControlCode("{CONTROL-:}", 0x1B );
        encoding.MapControlCode("{CONTROL-;}", 0x1D );
        encoding.MapControlCode("{CONTROL-=}", 0x1F );
        encoding.MapControlCode("{CONTROL-@}", 0x00 );
        encoding.MapControlCode("{CONTROL-A}", 0x01 );
        encoding.MapControlCode("{CONTROL-B}", 0x02 );
        encoding.MapControlCode("{CONTROL-C}", 0x03 );
        encoding.MapControlCode("{CONTROL-D}", 0x04 );
        encoding.MapControlCode("{CONTROL-E}", 0x05 );
        encoding.MapControlCode("{CONTROL-F}", 0x06 );
        encoding.MapControlCode("{CONTROL-G}", 0x07 );
        encoding.MapControlCode("{CONTROL-H}", 0x08 );
        encoding.MapControlCode("{CONTROL-I}", 0x09 );
        encoding.MapControlCode("{CONTROL-J}", 0x0A );
        encoding.MapControlCode("{CONTROL-K}", 0x0B );
        encoding.MapControlCode("{CONTROL-LEFT ARROW}", 0x06 );
        encoding.MapControlCode("{CONTROL-L}", 0x0C );
        encoding.MapControlCode("{CONTROL-M}", 0x0D );
        encoding.MapControlCode("{CONTROL-N}", 0x0E );
        encoding.MapControlCode("{CONTROL-O}", 0x0F );
        encoding.MapControlCode("{CONTROL-POUND}", 0x1C );
        encoding.MapControlCode("{CONTROL-P}", 0x10 );
        encoding.MapControlCode("{CONTROL-Q}", 0x11 );
        encoding.MapControlCode("{CONTROL-R}", 0x12 );
        encoding.MapControlCode("{CONTROL-S}", 0x13 );
        encoding.MapControlCode("{CONTROL-T}", 0x14 );
        encoding.MapControlCode("{CONTROL-UP ARROW}", 0x1E );
        encoding.MapControlCode("{CONTROL-U}", 0x15 );
        encoding.MapControlCode("{CONTROL-V}", 0x16 );
        encoding.MapControlCode("{CONTROL-W}", 0x17 );
        encoding.MapControlCode("{CONTROL-X}", 0x18 );
        encoding.MapControlCode("{CONTROL-Y}", 0x19 );
        encoding.MapControlCode("{CONTROL-Z}", 0x1A );
        encoding.MapControlCode("{CR}", 0x0D );
        encoding.MapControlCode("{CYAN}", 0x9F );
        encoding.MapControlCode("{CYN}", 0x9F );
        encoding.MapControlCode("{DELETE}", 0x14 );
        encoding.MapControlCode("{DEL}", 0x14 );
        encoding.MapControlCode("{DISH}", 0x08 );
        encoding.MapControlCode("{DOWN}", 0x11 );
        encoding.MapControlCode("{ENSH}", 0x09 );
        encoding.MapControlCode("{ESC}", 0x1B );
        encoding.MapControlCode("{F10}", 0x82 );
        encoding.MapControlCode("{F11}", 0x84 );
        encoding.MapControlCode("{F12}", 0x8F );
        encoding.MapControlCode("{F1}", 0x85 );
        encoding.MapControlCode("{F2}", 0x89 );
        encoding.MapControlCode("{F3}", 0x86 );
        encoding.MapControlCode("{F4}", 0x8A );
        encoding.MapControlCode("{F5}", 0x87 );
        encoding.MapControlCode("{F6}", 0x8B );
        encoding.MapControlCode("{F7}", 0x88 );
        encoding.MapControlCode("{F8}", 0x8C );
        encoding.MapControlCode("{F9}", 0x80 );
        encoding.MapControlCode("{GRAY1}", 0x97 );
        encoding.MapControlCode("{GRAY2}", 0x98 );
        encoding.MapControlCode("{GRAY3}", 0x9B );
        encoding.MapControlCode("{GREEN}", 0x1E );
        encoding.MapControlCode("{GREY1}", 0x97 );
        encoding.MapControlCode("{GREY2}", 0x98 );
        encoding.MapControlCode("{GREY3}", 0x9B );
        encoding.MapControlCode("{GRN}", 0x1E );
        encoding.MapControlCode("{GRY1}", 0x97 );
        encoding.MapControlCode("{GRY2}", 0x98 );
        encoding.MapControlCode("{GRY3}", 0x9B );
        encoding.MapControlCode("{HELP}", 0x84 );
        encoding.MapControlCode("{HOME}", 0x13 );
        encoding.MapControlCode("{INSERT}", 0x94 );
        encoding.MapControlCode("{INST}", 0x94 );
        encoding.MapControlCode("{LBLU}", 0x9A );
        encoding.MapControlCode("{LEFT ARROW}", 0x5F );
        encoding.MapControlCode("{LEFT}", 0x9D );
        encoding.MapControlCode("{LF}", 0x0A );
        encoding.MapControlCode("{LGRN}", 0x99 );
        encoding.MapControlCode("{LOWER CASE}", 0x0E );
        encoding.MapControlCode("{LRED}", 0x96 );
        encoding.MapControlCode("{LT BLUE}", 0x9A );
        encoding.MapControlCode("{LT GREEN}", 0x99 );
        encoding.MapControlCode("{LT RED}", 0x96 );
        encoding.MapControlCode("{ORANGE}", 0x81 );
        encoding.MapControlCode("{ORNG}", 0x81 );
        encoding.MapControlCode("{PI}", 0xFF );
        encoding.MapControlCode("{POUND}", 0x5C );
        encoding.MapControlCode("{PURPLE}", 0x9C );
        encoding.MapControlCode("{PUR}", 0x9C );
        encoding.MapControlCode("{RED}", 0x1C );
        encoding.MapControlCode("{RETURN}", 0x0D );
        encoding.MapControlCode("{REVERSE OFF}", 0x92 );
        encoding.MapControlCode("{REVERSE ON}", 0x12 );
        encoding.MapControlCode("{RGHT}", 0x1D );
        encoding.MapControlCode("{RIGHT}", 0x1D );
        encoding.MapControlCode("{RUN}", 0x83 );
        encoding.MapControlCode("{RVOF}", 0x92 );
        encoding.MapControlCode("{RVON}", 0x12 );
        encoding.MapControlCode("{RVS OFF}", 0x92 );
        encoding.MapControlCode("{RVS ON}", 0x12 );
        encoding.MapControlCode("{SHIFT RETURN}", 0x8D );
        encoding.MapControlCode("{SHIFT-*}", 0xC0 );
        encoding.MapControlCode("{SHIFT-+}", 0xDB );
        encoding.MapControlCode("{SHIFT-,}", 0x3C );
        encoding.MapControlCode("{SHIFT--}", 0xDD );
        encoding.MapControlCode("{SHIFT-.}", 0x3E );
        encoding.MapControlCode("{SHIFT-/}", 0x3F );
        encoding.MapControlCode("{SHIFT-0}", 0x30 );
        encoding.MapControlCode("{SHIFT-1}", 0x21 );
        encoding.MapControlCode("{SHIFT-2}", 0x22 );
        encoding.MapControlCode("{SHIFT-3}", 0x23 );
        encoding.MapControlCode("{SHIFT-4}", 0x24 );
        encoding.MapControlCode("{SHIFT-5}", 0x25 );
        encoding.MapControlCode("{SHIFT-6}", 0x26 );
        encoding.MapControlCode("{SHIFT-7}", 0x27 );
        encoding.MapControlCode("{SHIFT-8}", 0x28 );
        encoding.MapControlCode("{SHIFT-9}", 0x29 );
        encoding.MapControlCode("{SHIFT-:}", 0x5B );
        encoding.MapControlCode("{SHIFT-;}", 0x5D );
        encoding.MapControlCode("{SHIFT-@}", 0xBA );
        encoding.MapControlCode("{SHIFT-^}", 0xDE );
        encoding.MapControlCode("{SHIFT-A}", 0xC1 );
        encoding.MapControlCode("{SHIFT-B}", 0xC2 );
        encoding.MapControlCode("{SHIFT-C}", 0xC3 );
        encoding.MapControlCode("{SHIFT-D}", 0xC4 );
        encoding.MapControlCode("{SHIFT-E}", 0xC5 );
        encoding.MapControlCode("{SHIFT-F}", 0xC6 );
        encoding.MapControlCode("{SHIFT-G}", 0xC7 );
        encoding.MapControlCode("{SHIFT-H}", 0xC8 );
        encoding.MapControlCode("{SHIFT-I}", 0xC9 );
        encoding.MapControlCode("{SHIFT-J}", 0xCA );
        encoding.MapControlCode("{SHIFT-K}", 0xCB );
        encoding.MapControlCode("{SHIFT-L}", 0xCC );
        encoding.MapControlCode("{SHIFT-M}", 0xCD );
        encoding.MapControlCode("{SHIFT-N}", 0xCE );
        encoding.MapControlCode("{SHIFT-O}", 0xCF );
        encoding.MapControlCode("{SHIFT-POUND}", 0xA9 );
        encoding.MapControlCode("{SHIFT-P}", 0xD0 );
        encoding.MapControlCode("{SHIFT-Q}", 0xD1 );
        encoding.MapControlCode("{SHIFT-R}", 0xD2 );
        encoding.MapControlCode("{SHIFT-SPACE}", 0xA0 );
        encoding.MapControlCode("{SHIFT-S}", 0xD3 );
        encoding.MapControlCode("{SHIFT-T}", 0xD4 );
        encoding.MapControlCode("{SHIFT-UP ARROW}", 0xDE );
        encoding.MapControlCode("{SHIFT-U}", 0xD5 );
        encoding.MapControlCode("{SHIFT-V}", 0xD6 );
        encoding.MapControlCode("{SHIFT-W}", 0xD7 );
        encoding.MapControlCode("{SHIFT-X}", 0xD8 );
        encoding.MapControlCode("{SHIFT-Y}", 0xD9 );
        encoding.MapControlCode("{SHIFT-Z}", 0xDA );
        encoding.MapControlCode("{SPACE}", 0x20 );
        encoding.MapControlCode("{SRET}", 0x8D );
        encoding.MapControlCode("{STOP}", 0x03 );
        encoding.MapControlCode("{SWLC}", 0x0E );
        encoding.MapControlCode("{SWUC}", 0x8E );
        encoding.MapControlCode("{TAB}", 0x09 );
        encoding.MapControlCode("{UP ARROW}", 0x5E );
        encoding.MapControlCode("{UP/LO LOCK OFF}", 0x09 );
        encoding.MapControlCode("{UP/LO LOCK ON}", 0x08 );
        encoding.MapControlCode("{UPPER CASE}", 0x8E );
        encoding.MapControlCode("{UP}", 0x91 );
        encoding.MapControlCode("{WHITE}", 0x05 );
        encoding.MapControlCode("{WHT}", 0x05 );
        encoding.MapControlCode("{YELLOW}", 0x9E );
        encoding.MapControlCode("{YEL}", 0x9E );

        encoding.SelectEncoding("\"cbmscreen\"");
        encoding.Map("@Z", '\0');
        encoding.Map("az", 'A');
        encoding.Map('£', '\\');
        encoding.Map('π', '^'); // π is $5e in unshifted
        encoding.Map('↑', '^'); // ↑ is $5e in shifted
        encoding.Map('←', '_');
        encoding.Map('▌', '`');
        encoding.Map('▄', 'a');
        encoding.Map('▔', 'b');
        encoding.Map('▁', 'c');
        encoding.Map('▏', 'd');
        encoding.Map('▒', 'e');
        encoding.Map('▕', 'f');
        encoding.Map('◤', 'i');
        encoding.Map('├', 'k');
        encoding.Map('└', 'm');
        encoding.Map('┐', 'n');
        encoding.Map('▂', 'o');
        encoding.Map('┌', 'p');
        encoding.Map('┴', 'q');
        encoding.Map('┬', 'r');
        encoding.Map('┤', 's');
        encoding.Map('▎', 't');
        encoding.Map('▍', 'u');
        encoding.Map('▃', 'y');
        encoding.Map('✓', 'z');
        encoding.Map('┘', '}');
        encoding.Map('━', '@');
        encoding.Map('♠', 'A');
        encoding.Map('│', 'B');
        encoding.Map('╮', 'I');
        encoding.Map('╰', 'J');
        encoding.Map('╯', 'K');
        encoding.Map('╲', 'M');
        encoding.Map('╱', 'N');
        encoding.Map('●', 'Q');
        encoding.Map('♥', 'S');
        encoding.Map('╭', 'U');
        encoding.Map('╳', 'V');
        encoding.Map('○', 'W');
        encoding.Map('♣', 'X');
        encoding.Map('♦', 'Z');
        encoding.Map('┼', '[');
        encoding.Map('◥', '_');
        encoding.Map("\x80\xff", 0x80);

        encoding.MapControlCode("{CBM-*}", 0x5F);
        encoding.MapControlCode("{CBM-+}", 0x66);
        encoding.MapControlCode("{CBM--}", 0x5C);
        encoding.MapControlCode("{CBM-0}", 0x30);
        encoding.MapControlCode("{CBM-9}", 0x29);
        encoding.MapControlCode("{CBM-@}", 0x64);
        encoding.MapControlCode("{CBM-^}", 0x5E);
        encoding.MapControlCode("{CBM-A}", 0x70);
        encoding.MapControlCode("{CBM-B}", 0x7F);
        encoding.MapControlCode("{CBM-C}", 0x7C);
        encoding.MapControlCode("{CBM-D}", 0x6C);
        encoding.MapControlCode("{CBM-E}", 0x71);
        encoding.MapControlCode("{CBM-F}", 0x7B);
        encoding.MapControlCode("{CBM-G}", 0x65);
        encoding.MapControlCode("{CBM-H}", 0x74);
        encoding.MapControlCode("{CBM-I}", 0x62);
        encoding.MapControlCode("{CBM-J}", 0x75);
        encoding.MapControlCode("{CBM-K}", 0x61);
        encoding.MapControlCode("{CBM-L}", 0x76);
        encoding.MapControlCode("{CBM-M}", 0x67);
        encoding.MapControlCode("{CBM-N}", 0x6A);
        encoding.MapControlCode("{CBM-O}", 0x79);
        encoding.MapControlCode("{CBM-POUND}", 0x68);
        encoding.MapControlCode("{CBM-P}", 0x6F);
        encoding.MapControlCode("{CBM-Q}", 0x6B);
        encoding.MapControlCode("{CBM-R}", 0x72);
        encoding.MapControlCode("{CBM-S}", 0x6E);
        encoding.MapControlCode("{CBM-T}", 0x63);
        encoding.MapControlCode("{CBM-UP ARROW}", 0x5E);
        encoding.MapControlCode("{CBM-U}", 0x78);
        encoding.MapControlCode("{CBM-V}", 0x7E);
        encoding.MapControlCode("{CBM-W}", 0x73);
        encoding.MapControlCode("{CBM-X}", 0x7D);
        encoding.MapControlCode("{CBM-Y}", 0x77);
        encoding.MapControlCode("{CBM-Z}", 0x6D);
        encoding.MapControlCode("{LEFT ARROW}", 0x1F);
        encoding.MapControlCode("{PI}", 0x5E);
        encoding.MapControlCode("{POUND}", 0x1C);
        encoding.MapControlCode("{SHIFT-*}", 0x40);
        encoding.MapControlCode("{SHIFT-+}", 0x5B);
        encoding.MapControlCode("{SHIFT-,}", 0x3C);
        encoding.MapControlCode("{SHIFT--}", 0x5D);
        encoding.MapControlCode("{SHIFT-.}", 0x3E);
        encoding.MapControlCode("{SHIFT-/}", 0x3F);
        encoding.MapControlCode("{SHIFT-0}", 0x30);
        encoding.MapControlCode("{SHIFT-1}", 0x21);
        encoding.MapControlCode("{SHIFT-2}", 0x22);
        encoding.MapControlCode("{SHIFT-3}", 0x23);
        encoding.MapControlCode("{SHIFT-4}", 0x24);
        encoding.MapControlCode("{SHIFT-5}", 0x25);
        encoding.MapControlCode("{SHIFT-6}", 0x26);
        encoding.MapControlCode("{SHIFT-7}", 0x27);
        encoding.MapControlCode("{SHIFT-8}", 0x28);
        encoding.MapControlCode("{SHIFT-9}", 0x29);
        encoding.MapControlCode("{SHIFT-:}", 0x1B);
        encoding.MapControlCode("{SHIFT-;}", 0x1D);
        encoding.MapControlCode("{SHIFT-@}", 0x7A);
        encoding.MapControlCode("{SHIFT-^}", 0x5E);
        encoding.MapControlCode("{SHIFT-A}", 0x41);
        encoding.MapControlCode("{SHIFT-B}", 0x42);
        encoding.MapControlCode("{SHIFT-C}", 0x43);
        encoding.MapControlCode("{SHIFT-D}", 0x44);
        encoding.MapControlCode("{SHIFT-E}", 0x45);
        encoding.MapControlCode("{SHIFT-F}", 0x46);
        encoding.MapControlCode("{SHIFT-G}", 0x47);
        encoding.MapControlCode("{SHIFT-H}", 0x48);
        encoding.MapControlCode("{SHIFT-I}", 0x49);
        encoding.MapControlCode("{SHIFT-J}", 0x4A);
        encoding.MapControlCode("{SHIFT-K}", 0x4B);
        encoding.MapControlCode("{SHIFT-L}", 0x4C);
        encoding.MapControlCode("{SHIFT-M}", 0x4D);
        encoding.MapControlCode("{SHIFT-N}", 0x4E);
        encoding.MapControlCode("{SHIFT-O}", 0x4F);
        encoding.MapControlCode("{SHIFT-POUND}", 0x69);
        encoding.MapControlCode("{SHIFT-P}", 0x50);
        encoding.MapControlCode("{SHIFT-Q}", 0x51);
        encoding.MapControlCode("{SHIFT-R}", 0x52);
        encoding.MapControlCode("{SHIFT-SPACE}", 0x60);
        encoding.MapControlCode("{SHIFT-S}", 0x53);
        encoding.MapControlCode("{SHIFT-T}", 0x54);
        encoding.MapControlCode("{SHIFT-UP ARROW}", 0x5E);
        encoding.MapControlCode("{SHIFT-U}", 0x55);
        encoding.MapControlCode("{SHIFT-V}", 0x56);
        encoding.MapControlCode("{SHIFT-W}", 0x57);
        encoding.MapControlCode("{SHIFT-X}", 0x58);
        encoding.MapControlCode("{SHIFT-Y}", 0x59);
        encoding.MapControlCode("{SHIFT-Z}", 0x5A);
        encoding.MapControlCode("{SPACE}", 0x20);
        encoding.MapControlCode("{UP ARROW}", 0x1E);

        encoding.SelectEncoding("\"atascreen\"");
        encoding.Map(" _", '\0');
        encoding.Map("\x80\xff", 0x80);

        encoding.SelectDefaultEncoding();
    }
}
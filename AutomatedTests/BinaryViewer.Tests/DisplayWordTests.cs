using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.Tests
{
    [TestFixture]
    class DisplayWordTests
    {
        [Test]
        public void TestGetPadSizeInvalid()
        {
            Assert.Throws<ArgumentException>(delegate { DisplayWord.GetPadSize(BinaryDisplaySize.Byte, (BinaryDisplayStyle) 15); });
        }

        [Test, TestCaseSource(nameof(GetPadSizeSources))]
        public void TestGetPadSize(BinaryDisplayStyle style, BinaryDisplaySize size, int padSize)
        {
            Assert.AreEqual(padSize, DisplayWord.GetPadSize(size, style));
        }

        public static object[] GetPadSizeSources =
        {
            new object[] { BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Byte, 0 },
            new object[] { BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Short, 0 },
            new object[] { BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Int, 0 },
            new object[] { BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Long, 0 },
            new object[] { BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Byte, 0 },
            new object[] { BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Short, 0 },
            new object[] { BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Int, 0 },
            new object[] { BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Long, 0 },
            new object[] { BinaryDisplayStyle.Hex, BinaryDisplaySize.Byte, 2 },
            new object[] { BinaryDisplayStyle.Hex, BinaryDisplaySize.Short, 4 },
            new object[] { BinaryDisplayStyle.Hex, BinaryDisplaySize.Int, 8 },
            new object[] { BinaryDisplayStyle.Hex, BinaryDisplaySize.Long, 16 },
            new object[] { BinaryDisplayStyle.Binary, BinaryDisplaySize.Byte, 8 },
            new object[] { BinaryDisplayStyle.Binary, BinaryDisplaySize.Short, 16 },
            new object[] { BinaryDisplayStyle.Binary, BinaryDisplaySize.Int, 32 },
            new object[] { BinaryDisplayStyle.Binary, BinaryDisplaySize.Long, 64 },
        };

        [Test, TestCaseSource(nameof(FormatDisplayValueSources))]
        public void TestFormatDisplayValue(string input, BinaryDisplayStyle style, BinaryDisplaySize size, string output)
        {
            Assert.AreEqual(output, DisplayWord.FormatDisplayValue(input, size, style));
        }

        public static object[] FormatDisplayValueSources =
        {
            new object[] { "0", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Byte, "0" },
            new object[] { "0", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Short, "0" },
            new object[] { "0", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Int, "0" },
            new object[] { "123456", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Int, "123,456" },
            new object[] { "-123456", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Int, "-123,456" },
            new object[] { "0", BinaryDisplayStyle.SignedDecimal, BinaryDisplaySize.Long, "0" },
            new object[] { "0", BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Byte, "0" },
            new object[] { "0", BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Short, "0" },
            new object[] { "0", BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Int, "0" },
            new object[] { "1112378", BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Int, "1,112,378" },
            new object[] { "0", BinaryDisplayStyle.UnsignedDecimal, BinaryDisplaySize.Long, "0" },
            new object[] { "0", BinaryDisplayStyle.Hex, BinaryDisplaySize.Byte, "00" },
            new object[] { "0", BinaryDisplayStyle.Hex, BinaryDisplaySize.Short, "0000" },
            new object[] { "0", BinaryDisplayStyle.Hex, BinaryDisplaySize.Int, "0000 0000" },
            new object[] { "0", BinaryDisplayStyle.Hex, BinaryDisplaySize.Long, "0000 0000 0000 0000" },
            new object[] { "0", BinaryDisplayStyle.Binary, BinaryDisplaySize.Byte, "0000 0000" },
            new object[] { "0", BinaryDisplayStyle.Binary, BinaryDisplaySize.Short, "0000 0000 0000 0000" },
            new object[] { "0", BinaryDisplayStyle.Binary, BinaryDisplaySize.Int, "0000 0000 0000 0000 0000 0000 0000 0000" },
            new object[] { "0", BinaryDisplayStyle.Binary, BinaryDisplaySize.Long, "0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000" },
        };
    }
}

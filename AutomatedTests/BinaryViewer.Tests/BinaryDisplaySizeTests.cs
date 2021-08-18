using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.Tests
{
    [TestFixture]
    class BinaryDisplaySizeTests
    {
        [Test, TestCaseSource(nameof(NumBytesSources))]
        public void TestNumBytes(BinaryDisplaySize size, int numBytes)
        {
            Assert.AreEqual(numBytes, size.NumBytes());
        }

        public static object[] NumBytesSources =
        {
            new object[] { BinaryDisplaySize.Byte, 1 },
            new object[] { BinaryDisplaySize.Short, 2 },
            new object[] { BinaryDisplaySize.Int, 4 },
            new object[] { BinaryDisplaySize.Long, 8 },
        };
    }
}

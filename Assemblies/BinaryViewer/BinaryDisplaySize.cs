using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public enum BinaryDisplaySize
    {
        Byte = 1,
        Short = 2,
        Int = 4,
        Long = 8,
    }

    public static class BinaryDisplaySizeExtender
    {

        public static int NumBytes(this BinaryDisplaySize size)
        {
            return (int) size;
        }

    }
}

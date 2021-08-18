using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public enum BinaryDisplayStyle
    {
        Hex,
        Binary,
        SignedDecimal,
        UnsignedDecimal,
    }

    public static class BinaryDisplayStyleExtender
    {
        public static int Base(this BinaryDisplayStyle style)
        {
            switch (style)
            {
                case BinaryDisplayStyle.Binary: return 2;
                case BinaryDisplayStyle.SignedDecimal: return 10;
                case BinaryDisplayStyle.UnsignedDecimal: return 10;
                case BinaryDisplayStyle.Hex: return 16;
            }

            throw new ArgumentException("BinaryDisplayStyleExtender.Base() called with unknown style: " + style);
        }


        public static bool IsSigned(this BinaryDisplayStyle style)
        {
            switch (style)
            {
                case BinaryDisplayStyle.SignedDecimal:
                    return true;
                default:
                    return false;
            }
        }
    }

}

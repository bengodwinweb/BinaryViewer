using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public class DisplayWord
    {

        public long WordNumber { get; set; }

        public string WordValue { get; set; }

        public DisplayWord() { }

        public DisplayWord(long index, string value)
        {
            WordNumber = index;
            WordValue = value;
        }

        /// <summary>
        /// Returns true if WordValue contains the searchString.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public bool IsMatch(string searchString)
        {
            bool match = false;

            if (WordValue != null)
            {
                match = WordValue.Contains(searchString);
            }

            return match;
        }

        public static string FormatDisplayValue(string converted, BinaryDisplaySize size, BinaryDisplayStyle format)
        {
            // If decimal, format as number string with commas and no decimal places
            if (format == BinaryDisplayStyle.SignedDecimal || format == BinaryDisplayStyle.UnsignedDecimal)
            {
                // format as a number with commas (move this up a level so we don't go int -> string -> int -> string ??)
                if (size == BinaryDisplaySize.Long && format == BinaryDisplayStyle.UnsignedDecimal)
                {
                    return ulong.Parse(converted).ToString("N0");
                }
                else
                {
                    return long.Parse(converted).ToString("N0");
                }
            }
            else
            {
                // If hex, uppercase letters
                if (format == BinaryDisplayStyle.Hex)
                {
                    converted = converted.ToUpper();
                }

                // Pad left if leading zeros
                converted = converted.PadLeft(GetPadSize(size, format), '0');

                // Add spaces every four characters
                converted = Regex.Replace(converted, ".{4}", "$0 ").TrimEnd();
            }

            return converted;
        }

        public static int GetPadSize(BinaryDisplaySize size, BinaryDisplayStyle format)
        {
            switch (format)
            {
                case BinaryDisplayStyle.SignedDecimal:
                case BinaryDisplayStyle.UnsignedDecimal:
                    return 0;
                case BinaryDisplayStyle.Hex:
                    return size.NumBytes() * 2;
                case BinaryDisplayStyle.Binary:
                    return size.NumBytes() * 8;
            }

            throw new ArgumentException("DisplayWord.GetPadSize() unexpected format: " + format);
        }
    }
}

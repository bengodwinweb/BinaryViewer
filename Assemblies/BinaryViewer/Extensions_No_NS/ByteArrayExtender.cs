using System;
using System.Runtime.InteropServices;

namespace BinaryViewer
{
    public static class ByteArrayExtender
    {

        public static void FlipByteOrder(this byte[] b)
        {
            byte temp;

            for (int i = 0; i < b.Length - 1; i += 2)
            {
                temp = b[i];
                b[i] = b[i + 1];
                b[i + 1] = temp;
            }
        }

        public static T MarshalToStruct<T>(this byte[] b, int startIndex, out int length)
        {
            byte[] buffer = new byte[Marshal.SizeOf(default(T))];
            length = buffer.Length;

            Array.Copy(b, startIndex, buffer, 0, length);
            buffer.FlipByteOrder();
            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            try
            {
                return Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }

        public static string GetNextValue(this byte[] b, int index, BinaryDisplaySize size, BinaryDisplayStyle displayFormat)
        {
            if (displayFormat.IsSigned())
            {
                switch (size)
                {
                    case BinaryDisplaySize.Byte:
                        return Convert.ToString((sbyte) b[index], displayFormat.Base());
                    case BinaryDisplaySize.Short:
                        return Convert.ToString(b.GetInt16(index), displayFormat.Base());
                    case BinaryDisplaySize.Int:
                        return Convert.ToString(b.GetInt32(index), displayFormat.Base());
                    case BinaryDisplaySize.Long:
                        return Convert.ToString(b.GetInt64(index), displayFormat.Base());
                }
            }
            else
            {
                switch (size)
                {
                    case BinaryDisplaySize.Byte:
                        return Convert.ToString(b[index], displayFormat.Base());
                    case BinaryDisplaySize.Short:
                        return Convert.ToString(b.GetUInt16(index), displayFormat.Base());
                    case BinaryDisplaySize.Int:
                        return Convert.ToString(b.GetUInt32(index), displayFormat.Base());
                    case BinaryDisplaySize.Long: // no Convert.ToString(ulong val, int base) method
                        switch (displayFormat)
                        {
                            case BinaryDisplayStyle.Hex:
                            case BinaryDisplayStyle.Binary:
                                return Convert.ToString(b.GetInt64(index), displayFormat.Base()); // hex/binary don't look any different signed or not
                            default:
                                return Convert.ToString(b.GetUInt64(index)); // just turning it into a decimal string so this should do the trick
                        }
                }
            }

            throw new ArgumentException("ByteArrayExtender.GetNextValue(), Unhandled size " + size);
        }

        public static short GetInt16(this byte[] bytes, int index)
        {
            byte[] data = new byte[2];
            Array.Copy(bytes, index, data, 0, 2);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt16(data, 0);
        }

        public static ushort GetUInt16(this byte[] bytes, int index)
        {
            byte[] data = new byte[2];
            Array.Copy(bytes, index, data, 0, 2);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt16(data, 0);
        }

        public static int GetInt32(this byte[] bytes, int index)
        {
            byte[] data = new byte[4];
            Array.Copy(bytes, index, data, 0, 4);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt32(data, 0);
        }

        public static uint GetUInt32(this byte[] bytes, int index)
        {
            byte[] data = new byte[4];
            Array.Copy(bytes, index, data, 0, 4);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt32(data, 0);
        }

        public static long GetInt64(this byte[] bytes, int index)
        {
            byte[] data = new byte[8];
            Array.Copy(bytes, index, data, 0, 8);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt64(data, 0);
        }

        public static ulong GetUInt64(this byte[] bytes, int index)
        {
            byte[] data = new byte[8];
            Array.Copy(bytes, index, data, 0, 8);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt64(data, 0);
        }

    }
}

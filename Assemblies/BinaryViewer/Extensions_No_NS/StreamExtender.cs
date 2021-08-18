using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BinaryViewer
{

    public static class StreamExtender
    {

        public static T ReadStruct<T>(this Stream stream) where T : struct
        {
            if (stream == null)
            {
                throw new ArgumentException("StreamExtender.ReadStruct() called with null");
            }

            byte[] bytes = new byte[Marshal.SizeOf(default(T))];
            stream.Read(bytes, 0, bytes.Length);

            return bytes.MarshalToStruct<T>(0, out int ignore);
        }

        public static int ReadInt32(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentException("ReadInt32(" + nameof(stream) + " == null)");
            }

            // Get the int32 data.
            byte[] data = new byte[4];

            data[0] = (byte) stream.ReadByte();
            data[1] = (byte) stream.ReadByte();
            data[2] = (byte) stream.ReadByte();
            data[3] = (byte) stream.ReadByte();

            // Ensure we have the correct byte order.
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            // Parse the integer
            return BitConverter.ToInt32(data, 0);
        }

        public static short ReadInt16(this Stream stream)
        {
            return BitConverter.ToInt16(ReadTwoBytes(stream), 0);
        }

        public static ushort ReadUInt16(this Stream stream)
        {
            return BitConverter.ToUInt16(ReadTwoBytes(stream), 0);
        }

        static byte[] ReadTwoBytes(this Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentException("ReadInt32(" + nameof(stream) + " == null)");
            }

            // Get the int32 data.
            byte[] data = new byte[2];

            data[0] = (byte) stream.ReadByte();
            data[1] = (byte) stream.ReadByte();

            // Ensure we have the correct byte order.
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return data;
        }

    }
}

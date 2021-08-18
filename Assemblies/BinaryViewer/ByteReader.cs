using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{

    public class ByteReader : IByteReader
    {

        public byte[] ReadFromFile(string filePath, long start, long bytesToRead)
        {
            var file = new FileInfo(filePath);

            if (!file.Exists)
            {
                throw new ArgumentException(string.Format("File: \"{0}\" does not exist", filePath));
            }

            if (start > file.Length)
            {
                return new byte[0];
            }

            bytesToRead = Math.Min(int.MaxValue, Math.Min(bytesToRead, file.Length - start));

            byte[] data = new byte[bytesToRead];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                stream.Seek(start, SeekOrigin.Begin);
                stream.Read(data, 0, (int) bytesToRead);
            }

            return data;
        }
    }
}

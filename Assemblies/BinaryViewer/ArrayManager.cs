using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{

    public class ArrayManager : IArrayManager
    {

        public ArrayManager()
        {
            ByteArray = new ByteArray();
        }

        public string ReadableFileName { get; private set; }

        public ByteArray ByteArray { get; }


        /// <summary>
        /// Search up (moving towards index 0) or down (moving towards CurrentDisplayList.Count)
        /// to find the next index in CurrentDisplayList that contains the searchString in its WordValue.
        /// If no matches are found, should return null.
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="searchString"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public int? FindNext(int currentIndex, string searchString, SearchDirection direction)
        {
            if (currentIndex >= 0 && currentIndex < ByteArray.DisplayList.Count)
            {
                switch (direction)
                {
                    case SearchDirection.Up:
                        for (int i = currentIndex; i >= 0; i--)
                        {
                            if (ByteArray.DisplayList[i].IsMatch(searchString))
                            {
                                return i;
                            }
                        }
                        break;
                    case SearchDirection.Down:
                        for (int i = currentIndex; i < ByteArray.DisplayList.Count; i++)
                        {
                            if (ByteArray.DisplayList[i].IsMatch(searchString))
                            {
                                return i;
                            }
                        }
                        break;
                }
            }

            return null;
        }


        public bool CanSave() => ReadableFileName != null;

        public void WriteReadableFile(string filePath)
        {
            ReadableFileName = filePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var lines = from word in ByteArray.DisplayList
                        select word.WordValue;

            File.WriteAllLines(filePath, lines);
        }
    }
}

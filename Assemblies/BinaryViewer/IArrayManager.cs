using System;
using System.Collections.Generic;

namespace BinaryViewer
{
    public interface IArrayManager
    {

        /// <summary>
        /// Name of the file to save readable data
        /// </summary>
        string ReadableFileName { get; }

        /// <summary>
        /// Indicates that a save can be performed without requiring a Save As first
        /// </summary>
        /// <returns></returns>
        bool CanSave();

        /// <summary>
        /// Instance of the ByteArray for display
        /// </summary>
        ByteArray ByteArray { get; }

        /// <summary>
        /// Searches for a partial match within a display word's WordValue. 
        /// Returns the next matching index in the CurrentDataList if found.
        /// Null if the end of the data was reached without finding a match.
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="searchString"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        int? FindNext(int currentIndex, string searchString, SearchDirection direction);

        /// <summary>
        /// Writes the display values as strings.
        /// Overwrites any existing file.
        /// </summary>
        void WriteReadableFile(string filePath);
    }
}

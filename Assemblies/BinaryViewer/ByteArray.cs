using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    /// <summary>
    /// Wrapper aroud a byte[]
    /// </summary>
    public class ByteArray : ModelBase
    {
        public ByteArray()
        {
            Data = new byte[0];
            StartingByte = 0;
            DisplayList = new List<DisplayWord>();

            WordSize = BinaryDisplaySize.Short;
            DisplayFormat = BinaryDisplayStyle.Hex;
        }

        public void UpdateData(byte[] data, long startingWord)
        {
            Data = data;
            StartingByte = startingWord;
            OnPropertyChanged(nameof(StartingByte));
            UpdateDisplayList(nameof(Data));
        }

        public long StartingByte { get; private set; }
        public byte[] Data { get; private set; }

        private int? _selectedIndex;
        public int? SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null)
                {
                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = 0;
                    }
                    else if (_selectedIndex >= DisplayList.Count)
                    {
                        _selectedIndex = DisplayList.Count - 1;
                    }
                }
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        private bool _findActive;
        public bool FindActive
        {
            get => _findActive;
            set
            {
                _findActive = value;
                OnPropertyChanged(nameof(FindActive));
            }
        }

        private List<DisplayWord> _displayList;
        public List<DisplayWord> DisplayList
        {
            get => _displayList;
            set
            {
                _displayList = value;
                if (_displayList == null)
                {
                    _displayList = new List<DisplayWord>();
                }
                OnPropertyChanged(nameof(DisplayList));
            }
        }

        private BinaryDisplaySize _wordSize;
        public BinaryDisplaySize WordSize
        {
            get => _wordSize;
            set
            {
                _wordSize = value;
                UpdateDisplayList(nameof(WordSize));
            }
        }

        private BinaryDisplayStyle _displayFormat;
        public BinaryDisplayStyle DisplayFormat
        {
            get => _displayFormat;
            set
            {
                _displayFormat = value;
                UpdateDisplayList(nameof(DisplayFormat));
            }
        }

        private void UpdateDisplayList(string propertyName)
        {
            DisplayWord[] words;

            if (Data.Length >= WordSize.NumBytes())
            {
                words = new DisplayWord[Data.Length / WordSize.NumBytes()];
            }
            else
            {
                words = new DisplayWord[0];
            }

            long displayWordsIndex = StartingByte / WordSize.NumBytes();
            int dataIndex = 0;
            for (dataIndex = 0; dataIndex < Data.Length; dataIndex += WordSize.NumBytes(), displayWordsIndex++)
            {
                string displayValue = DisplayWord.FormatDisplayValue(Data.GetNextValue(dataIndex, WordSize, DisplayFormat), WordSize, DisplayFormat);
                words[displayWordsIndex] = new DisplayWord(displayWordsIndex, displayValue);
            }

            SelectedIndex = 0;
            DisplayList = new List<DisplayWord>(words);
        }
    }
}

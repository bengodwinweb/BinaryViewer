using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public class OpenFileArguments : ModelBase
    {

        public OpenFileArguments()
        {
            _fileName = string.Empty;
            _firstByte = "0";
            _numBytes = int.MaxValue.ToString("N0");
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        private string _firstByte;
        public string FirstByteString
        {
            get => _firstByte;
            set
            {
                _firstByte = value;
                OnPropertyChanged(nameof(FirstByteString));
            }
        }

        private string _numBytes;
        public string NumBytesString
        {
            get => _numBytes;
            set
            {
                _numBytes = value;
                OnPropertyChanged(nameof(NumBytesString));
            }
        }

    }
}

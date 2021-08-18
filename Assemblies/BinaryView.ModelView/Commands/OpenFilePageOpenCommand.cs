using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ModelView.Commands
{
    public class OpenFilePageOpenCommand : CommandBase
    {
        private readonly IOpenFileViewModel _viewModel;
        private readonly IBinaryViewerManager _manager;

        public OpenFilePageOpenCommand(IOpenFileViewModel viewModel) : this(viewModel, BinaryViewerManager.Make()) { }

        public OpenFilePageOpenCommand(IOpenFileViewModel viewModel, IBinaryViewerManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }

        public override bool CanExecute(object parameter)
        {
            return CanOpenInternal(out var ignore);
        }

        public override void Execute(object parameter)
        {
            if (!CanOpenInternal(out string errString))
            {
                ErrorHelper.ShowError(errString);
                return;
            }

            TryParseFirstByte(out long firstByte, out string ignore);
            TryParseNumBytes(out int numBytes, out ignore);

            var bytes = _manager.ByteReader.ReadFromFile(_viewModel.OpenFileArguments.FileName, firstByte, numBytes);
            _manager.ArrayManager.ByteArray.UpdateData(bytes, firstByte);
            _viewModel.View.Close();
        }

        bool CanOpenInternal(out string errString)
        {
            errString = "";

            if (!File.Exists(_viewModel.OpenFileArguments.FileName))
            {
                errString = string.Format("File \"{0}\" not found", _viewModel.OpenFileArguments.FileName);
                return false;
            }
            else if (!TryParseFirstByte(out var firstByte, out errString))
            {
                return false;
            }
            else if (!TryParseNumBytes(out var numBytes, out errString))
            {
                return false;
            }

            return true;
        }


        bool TryParseFirstByte(out long firstByte, out string errString)
        {
            firstByte = -1;
            string firstByteString = _viewModel.OpenFileArguments.FirstByteString;
            errString = string.Format("Unable to parse first byte from \"{0}\"", firstByteString);

            if (!string.IsNullOrEmpty(firstByteString))
            {
                if (long.TryParse(firstByteString.Replace(",", ""), out firstByte))
                {
                    errString = "First byte cannot be negative";
                    return firstByte >= 0;
                }
            }

            return false;
        }

        bool TryParseNumBytes(out int numBytes, out string errString)
        {
            numBytes = -1;
            string numBytesString = _viewModel.OpenFileArguments.NumBytesString;
            errString = string.Format("Unable to parse bytes to read from \"{0}\"", numBytesString);

            if (!string.IsNullOrEmpty(numBytesString))
            {
                if (int.TryParse(numBytesString.Replace(",", ""), out numBytes))
                {
                    errString = "Bytes to read cannot be negative";
                    return numBytes >= 0;
                }
            }

            return false;
        }
    }
}

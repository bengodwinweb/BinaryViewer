using BinaryViewer.ModelView;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BinaryViewer.ModelView
{

}

namespace BinaryViewer.ModelView
{

}


namespace BinaryViewer.Wpf
{
    /// <summary>
    /// Interaction logic for OpenFileWindow.xaml
    /// </summary>
    public partial class OpenFileWindow : Window, IOpenFileWindow
    {
        readonly IOpenFileViewModel _viewModel;

        public OpenFileWindow()
        {
            InitializeComponent();
            _viewModel = new OpenFileViewModel(this);
            DataContext = _viewModel;
        }

        private void ChooseActivated(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                
                _viewModel.OpenFileArguments.FileName = openFileDialog.FileName;
            }
        }

    }
}

namespace BinaryViewer.Controller
{
    //public class OpenFileController
    //{
    //    readonly IOpenFileWindow _view;
    //    readonly IBinaryViewerManager _manager;

    //    public OpenFileController(IOpenFileWindow view, IBinaryViewerManager manager)
    //    {
    //        _view = view;
    //        _manager = manager;

    //        _view.CancelActivated += _view_CancelActivated;
    //        _view.OpenActivated += _view_OpenActivated;
    //    }

    //    void _view_OpenActivated(object sender, EventArgs e)
    //    {
    //        if (!CanOpen(out string errString))
    //        {
    //            _view.ShowError(errString);
    //            return;
    //        }

    //        TryParseFirstByte(out long firstByte, out string ignore);
    //        TryParseNumBytes(out int numBytes, out ignore);

    //        var bytes = _manager.ByteReader.ReadFromFile(_view.FileName, firstByte, numBytes);
    //        _manager.ArrayManager.UpdateData(bytes, firstByte);
    //        _view.Close();
    //    }

    //    void _view_CancelActivated(object sender, EventArgs e)
    //    {
    //        _view.Close();
    //    }

    //public bool CanOpen(out string errString)
    //{
    //    errString = "";

    //    if (!File.Exists(_view.FileName))
    //    {
    //        errString = string.Format("File \"{0}\" not found", _view.FileName);
    //        return false;
    //    }
    //    else if (!TryParseFirstByte(out var firstByte, out errString))
    //    {
    //        return false;
    //    }
    //    else if (!TryParseNumBytes(out var numBytes, out errString))
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    //bool TryParseFirstByte(out long firstByte, out string errString)
    //{
    //    firstByte = -1;
    //    string firstByteString = _view.FirstByte;
    //    errString = string.Format("Unable to parse first byte from \"{0}\"", firstByteString);

    //    if (!string.IsNullOrEmpty(firstByteString))
    //    {
    //        if (long.TryParse(firstByteString.Replace(",", ""), out firstByte))
    //        {
    //            errString = "First byte cannot be negative";
    //            return firstByte >= 0;
    //        }
    //    }

    //    return false;
    //}

    //    bool TryParseNumBytes(out int numBytes, out string errString)
    //    {
    //        numBytes = -1;
    //        string numBytesString = _view.BytesToRead;
    //        errString = string.Format("Unable to parse bytes to read from \"{0}\"", numBytesString);

    //        if (!string.IsNullOrEmpty(numBytesString))
    //        {
    //            if (int.TryParse(numBytesString.Replace(",", ""), out numBytes))
    //            {
    //                errString = "Bytes to read cannot be negative";
    //                return numBytes >= 0;
    //            }
    //        }

    //        return false;
    //    }
    //}
}

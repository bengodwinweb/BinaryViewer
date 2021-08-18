using BinaryViewer.ModelView.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ModelView
{
    public interface IOpenFileViewModel
    {
        IOpenFileWindow View { get; }

        OpenFileArguments OpenFileArguments { get; }
    }

    public class OpenFileViewModel : IOpenFileViewModel
    {
        readonly IBinaryViewerManager _manager;

        public OpenFileViewModel(IOpenFileWindow view) : this(view, BinaryViewerManager.Make()) { }

        public OpenFileViewModel(IOpenFileWindow view, IBinaryViewerManager manager)
        {
            View = view;
            _manager = manager;

            OpenFileArguments = new OpenFileArguments();

            OpenCommand = new OpenFilePageOpenCommand(this);
            CancelCommand = new OpenFileCancelCommand(this);
        }

        public IOpenFileWindow View { get; }

        public OpenFileArguments OpenFileArguments { get; private set; }

        public ICommand OpenCommand { get; }

        public ICommand CancelCommand { get; }
    }
}

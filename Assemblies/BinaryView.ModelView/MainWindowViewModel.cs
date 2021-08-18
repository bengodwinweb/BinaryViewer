using BinaryViewer.ModelView.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ModelView
{
    public interface IMainWindowViewModel
    {
        IMainView View { get; }

        ByteArray ByteArray { get; }

    }

    public class MainWindowViewModel : IMainWindowViewModel
    {
        readonly IBinaryViewerManager _manager;

        public MainWindowViewModel(IMainView view) : this(view, BinaryViewerManager.Make()) { }

        public MainWindowViewModel(IMainView view, IBinaryViewerManager manager)
        {
            View = view;
            _manager = manager;

            OpenCommand = new MainWindowOpenCommand(this);
            FindCommand = new MainWindowFindCommand(this);
            SaveCommand = new MainWindowSaveCommand(this);
            SaveAsCommand = new MainWindowSaveAsCommand(this);
            ExitCommand = new MainWindowExitCommand(this);
            WordSizeCommand = new MainWindowWordSizeCommand(this);
            WordFormatCommand = new MainWindowWordFormatCommand(this);
        }

        public ByteArray ByteArray => _manager.ArrayManager.ByteArray;

        public IMainView View { get; }

        public ICommand OpenCommand { get; }
        public ICommand FindCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand WordSizeCommand { get; }
        public ICommand WordFormatCommand { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowSaveCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;
        readonly IBinaryViewerManager _manager;

        public MainWindowSaveCommand(IMainWindowViewModel viewModel) : this(viewModel, BinaryViewerManager.Make()) { }

        public MainWindowSaveCommand(IMainWindowViewModel viewModel, IBinaryViewerManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }

        public override bool CanExecute(object parameter) => _manager.ArrayManager.CanSave();

        public override void Execute(object parameter)
        {
            _manager.ArrayManager.WriteReadableFile(_manager.ArrayManager.ReadableFileName);
        }
    }
}

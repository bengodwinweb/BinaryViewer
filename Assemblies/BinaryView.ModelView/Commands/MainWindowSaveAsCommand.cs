using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowSaveAsCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;
        readonly IBinaryViewerManager _manager;

        public MainWindowSaveAsCommand(IMainWindowViewModel viewModel) : this(viewModel, BinaryViewerManager.Make()) { }

        public MainWindowSaveAsCommand(IMainWindowViewModel viewModel, IBinaryViewerManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (_viewModel.View.GetFileNameFromUser(out string fileName))
            {
                _manager.ArrayManager.WriteReadableFile(fileName);
            }
        }
    }
}

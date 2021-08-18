using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowFindCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;

        public MainWindowFindCommand(IMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.ByteArray.FindActive == false;
        }

        public override void Execute(object parameter)
        {
            _viewModel.ByteArray.FindActive = true;
            _viewModel.View.GotoFind();
        }
    }
}

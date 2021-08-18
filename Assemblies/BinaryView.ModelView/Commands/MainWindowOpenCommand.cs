using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowOpenCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;

        public MainWindowOpenCommand(IMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            _viewModel.View.GotoOpenFileDialog();
        }
    }
}

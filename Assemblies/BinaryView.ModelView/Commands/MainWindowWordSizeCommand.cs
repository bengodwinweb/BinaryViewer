using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowWordSizeCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;

        public MainWindowWordSizeCommand(IMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var newSize = (BinaryDisplaySize) parameter;
            _viewModel.ByteArray.WordSize = newSize;
        }
    }
}

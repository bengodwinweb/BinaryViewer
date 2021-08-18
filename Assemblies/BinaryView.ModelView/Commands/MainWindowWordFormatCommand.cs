using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView.Commands
{
    public class MainWindowWordFormatCommand : CommandBase
    {
        readonly IMainWindowViewModel _viewModel;

        public MainWindowWordFormatCommand(IMainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var newFormat = (BinaryDisplayStyle) parameter;
            _viewModel.ByteArray.DisplayFormat = newFormat;
        }
    }
}

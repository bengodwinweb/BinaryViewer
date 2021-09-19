using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ProgressView
{
    public class CancelCommand : ICommand
    {
        private readonly IProgressViewModel _viewModel;

        public CancelCommand(IProgressViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += HandleViewModelUpdate;
        }

        public event EventHandler CanExecuteChanged;

        void HandleViewModelUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.CancelRequested) ||
                e.PropertyName == nameof(_viewModel.CompleteSuccess) ||
                e.PropertyName == nameof(_viewModel.CompleteCanceled) ||
                e.PropertyName == nameof(_viewModel.CompleteError))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return !_viewModel.CancelRequested && !_viewModel.CompleteSuccess && !_viewModel.CompleteCanceled && !_viewModel.CompleteError;
        }

        public void Execute(object parameter)
        {
            _viewModel.CancelRequested = true;
        }
    }
}

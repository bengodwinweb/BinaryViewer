using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BinaryViewer.ProgressView
{
    public class ProgressViewModel : NotifyBase, IProgressViewModel
    {
        readonly BackgroundWorker _worker;
        readonly ShowProgressArgs _args;

        public ProgressViewModel(IProgressView view, ShowProgressArgs args)
        {
            View = view;
            _args = args;
            _worker = args.Worker;

            OkButtonText = _args.OkButtonText;
            CancelButtonText = _args.CancelButtonText;
            Title = _args.Title;
            Description = _args.Description;
            StepString = string.Empty;

            Cancel = new CancelCommand(this);
            Ok = new OkCommand(this);

            _worker.ProgressChanged += HandleProgressUpdated;
            _worker.RunWorkerCompleted += HandleWorkerCompleted;
            View.Activated += _view_Activated;
        }

        private bool _workerStarted = false;

        void _view_Activated(object sender, EventArgs e)
        {
            if (!_workerStarted)
            {
                _workerStarted = true;
                _worker.RunWorkerAsync(_args.DoWorkArgs);
            }
        }

        void HandleProgressUpdated(object sender, ProgressChangedEventArgs e)
        {
            ProgressPercent = e.ProgressPercentage;
            StepString = e.UserState?.ToString() ?? string.Empty;
        }

        void HandleWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                CompleteCanceled = true;
                OkButtonText = _args.OkButtonTextAfterCancel;
                Description = "Cancelled";
                StepString = string.Empty;
                View.HideProgressBar();
            }
            if (e.Error != null)
            {
                CompleteCanceled = true;
                OkButtonText = _args.OkButtonTextAfterCancel;
                StepString = e.Error.Message;
                Description = "Error";
                View.HideProgressBar();
            }
            else if (!CompleteCanceled && !CompleteError)
            {
                CompleteSuccess = true;
                Description = "Success";
                StepString = string.Empty;
                Result = e.Result;

                if (_args.CloseOnSuccess)
                {
                    _args.OnSuccessHandler?.Invoke(Result);
                    View.Close();
                }
            }
        }


        public IProgressView View { get; }

        public ICommand Cancel { get; }

        public ICommand Ok { get; }

        private string _cancelButtonText = "Cancel";
        public string CancelButtonText
        {
            get => _cancelButtonText;
            set
            {
                _cancelButtonText = value;
                OnPropertyChanged(nameof(CancelButtonText));
            }
        }

        private string _okButtonText = "Ok";
        public string OkButtonText
        {
            get => _okButtonText;
            set
            {
                _okButtonText = value;
                OnPropertyChanged(nameof(OkButtonText));
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _stepString = string.Empty;
        public string StepString
        {
            get => _stepString;
            set
            {
                _stepString = value;
                OnPropertyChanged(nameof(StepString));
            }
        }

        private int _progressPercent;
        public int ProgressPercent
        {
            get => _progressPercent;
            set
            {
                _progressPercent = value;
                OnPropertyChanged(nameof(ProgressPercent));
            }
        }

        private bool _cancelRequested;
        public bool CancelRequested
        {
            get => _cancelRequested;
            set
            {
                _cancelRequested = value;
                _worker?.CancelAsync();
                OnPropertyChanged(nameof(CancelRequested));
            }
        }

        private bool _completeSucces;
        public bool CompleteSuccess
        {
            get => _completeSucces;
            set
            {
                _completeSucces = value;
                OnPropertyChanged(nameof(CompleteSuccess));
            }
        }

        private bool _completeCanceled;
        public bool CompleteCanceled
        {
            get => _completeCanceled;
            set
            {
                _completeCanceled = value;
                OnPropertyChanged(nameof(CompleteCanceled));
            }
        }

        private bool _completeError;
        public bool CompleteError
        {
            get => _completeError;
            set
            {
                _completeError = value;
                OnPropertyChanged(nameof(CompleteError));
            }
        }

        public object Result { get; private set; }

        public OnSuccessDelegate OnSuccessHandler => _args.OnSuccessHandler;

    }
}

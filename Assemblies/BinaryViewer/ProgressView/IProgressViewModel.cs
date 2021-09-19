using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ProgressView
{
    public interface IProgressViewModel : INotifyPropertyChanged
    {
        IProgressView View { get; }

        bool CancelRequested { get; set; }

        bool CompleteSuccess { get; }

        bool CompleteCanceled { get; }

        bool CompleteError { get; }

        object Result { get; }

        OnSuccessDelegate OnSuccessHandler { get; }
    }
}

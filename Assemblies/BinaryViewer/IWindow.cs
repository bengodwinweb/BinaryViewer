using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BinaryViewer
{
    public interface IWindow
    {
        event EventHandler SourceInitialized;
        event EventHandler Activated;
        event EventHandler Deactivated;
        event EventHandler StateChanged;
        event EventHandler ContentRendered;
        event CancelEventHandler Closing;
        event EventHandler Closed;

        bool IsActive { get; }

        void Close();

        Dispatcher Dispatcher { get; }
    }
}

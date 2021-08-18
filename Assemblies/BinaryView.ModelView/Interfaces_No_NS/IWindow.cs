using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BinaryViewer.ModelView
{
    /// <summary>
    /// Exposes methods and properties from Window control to ViewModel
    /// </summary>
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
        bool Topmost { get; }
        string Title { get; set; }
        WindowState WindowState { get; }

        void Close();
    }
}

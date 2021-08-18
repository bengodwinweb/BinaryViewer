using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer.ModelView
{
    public interface IMainView : IWindow
    {

        /// <summary>
        /// Shuts down the application
        /// </summary>
        void ExitApplication();

        /// <summary>
        /// Opens the OpenFileWindow form as a dialog
        /// </summary>
        void GotoOpenFileDialog();

        /// <summary>
        /// Open the Find form
        /// </summary>
        void GotoFind();

        /// <summary>
        /// Gets the file name from the user for use in a Save As command
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool GetFileNameFromUser(out string fileName);
    }
}

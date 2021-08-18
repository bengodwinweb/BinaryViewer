using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BinaryViewer.ModelView
{
    public static class ErrorHelper
    {

        public static MessageBoxResult ShowError(string errorString)
        {
            return MessageBox.Show(errorString, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, 0);
        }

        public static MessageBoxResult ShowError(string errorString, params object[] args)
        {
            return ShowError(string.Format(errorString, args));
        }
    }
}

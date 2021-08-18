using BinaryViewer.Controller;
using BinaryViewer.ModelView;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryViewer.Wpf
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        public bool GetFileNameFromUser(out string fileName)
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.DefaultExt = ".txt";
            dialog.ValidateNames = true;
            dialog.Title = "Save readable data to:";
            dialog.CheckFileExists = false;

            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;
                return true;
            }

            fileName = string.Empty;
            return false;
        }

        public void GotoFind()
        {
            MessageBox.Show("Not implemented");
        }

        public void GotoOpenFileDialog()
        {
            new OpenFileWindow().ShowDialog();
        }

    }
}

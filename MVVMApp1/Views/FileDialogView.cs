using Microsoft.Win32;
using MVVMApp1.Dialogs;
using System.Windows;

namespace MVVMApp1.Views
{
    // Implementation of IFileDialog for WPF
    // OpenFileDialog is sealed so we create a wrapper
    class FileDialogView : IFileDialog
    {
        readonly OpenFileDialog dialog;

        public string FileName { get { return dialog.FileName; } set { dialog.FileName = value; } }
        public string InitialDirectory { get { return dialog.InitialDirectory; } set { dialog.InitialDirectory = value; } }
        public string Filter { get { return dialog.Filter; } set { dialog.Filter = value; } }
        public string DefaultExt { get { return dialog.DefaultExt; } set { dialog.DefaultExt = value; } }
        public string Title { get { return dialog.Title; } set { dialog.Title = value; } }

        public FileDialogView(OpenFileDialog dialog)
        {
            this.dialog = dialog;
        }

        public bool? ShowDialog(object owner)
        {
            bool? result = dialog.ShowDialog(owner as Window);
            return result;
        }
    }
}
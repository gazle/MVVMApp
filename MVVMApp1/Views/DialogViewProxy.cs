using MVVMApp1.Dialogs;
using MVVMApp1.ViewModels;
using System;
using System.Windows;

namespace MVVMApp1.Views
{
    // Implementation of IDialog for WPF dialogs
    class DialogViewProxy : IDialog
    {
        public bool? ShowDialog(DialogViewModelBase viewModel, object owner)
        {
            DialogWindow window = new DialogWindow()
            {
                Owner = owner as Window,
                DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel))
            };
            void handler(object s, DialogResultEventArgs e)
            {
                window.DialogResult = e.Result;     // WPF DialogWindow will close
            }

            viewModel.CloseRequested += handler;
            bool? result = window.ShowDialog();     // Open WPF DialogWindow and wait here for it to close
            // DialogViewModel updates are handled via the callback supplied to the VM
            viewModel.CloseRequested -= handler;
            viewModel.DialogResult = result;
            // Return the DialogWindow DialogResult
            return result;
        }
    }
}
using MVVMApp1.ViewModels;

namespace MVVMApp1.Dialogs
{
    interface IDialog
    {
        //bool? DialogResult { get; set; }
        //object DataContext { get; set; }
        //Window Owner { get; set; }

        bool? ShowDialog(DialogViewModelBase viewModel, object owner);
    }
}
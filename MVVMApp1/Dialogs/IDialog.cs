using MVVMApp1.ViewModels;

namespace MVVMApp1.Dialogs
{
    interface IDialog
    {
        bool? ShowDialog(DialogViewModelBase viewModel, object owner);
    }
}
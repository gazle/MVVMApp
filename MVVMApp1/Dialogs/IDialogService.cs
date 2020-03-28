using MVVMApp1.ViewModels;

namespace MVVMApp1.Dialogs
{
    interface IDialogService
    {
        bool? OpenDialog(DialogViewModelBase viewModel, object owner);
    }
}
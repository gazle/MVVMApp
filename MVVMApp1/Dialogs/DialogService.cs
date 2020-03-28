using MVVMApp1.ViewModels;

namespace MVVMApp1.Dialogs
{
    class DialogService<TDialog> : IDialogService where TDialog : IDialog, new()
    {
        public bool? OpenDialog(DialogViewModelBase viewModel, object owner)
        {
            //var window = (IDialogWindow)Activator.CreateInstance(typeof(TDialogWindow));
            IDialog dialog = new TDialog();
            bool? result = dialog.ShowDialog(viewModel, owner);
            return result;
        }
    }
}
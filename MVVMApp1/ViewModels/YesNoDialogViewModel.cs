using System;

namespace MVVMApp1.ViewModels
{
    class YesNoDialogViewModel : DialogViewModelBase
    {
        public YesNoDialogViewModel(string title, string message, Action<DialogViewModelBase> applyCallback = null)
            : base(title, message, applyCallback)
        {
        }
    }
}
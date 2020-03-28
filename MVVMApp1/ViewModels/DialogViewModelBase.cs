using System;

namespace MVVMApp1.ViewModels
{
    abstract class DialogViewModelBase : ViewModelBase
    {
        public Action<DialogViewModelBase> ApplyCallback;
        public DelegateCommand YesCommand { get; protected set; }
        public DelegateCommand NoCommand { get; protected set; }
        public DelegateCommand OKCommand { get; protected set; }
        public DelegateCommand ApplyCommand { get; protected set; }
        public DelegateCommand CancelCommand { get; protected set; }

        public string Title { get; }
        public string Message { get; }
        public bool? DialogResult { get; set; }

        public event EventHandler<DialogResultEventArgs> CloseRequested;

        public DialogViewModelBase(string title = "", string message = "", Action<DialogViewModelBase> applyCallback = null)
        {
            YesCommand = new DelegateCommand(Yes, CanYes);
            NoCommand = new DelegateCommand(No, CanNo);
            OKCommand = new DelegateCommand(OK, CanOK);
            ApplyCommand = new DelegateCommand(Apply, CanApply);
            CancelCommand = new DelegateCommand(Cancel, CanCancel);
            DialogResult = null;
            Title = title;
            Message = message;
            ApplyCallback = applyCallback;
        }

        protected virtual void OnRequestClose(bool? result)
        {
            CloseRequested?.Invoke(this, new DialogResultEventArgs(result));
        }

        protected virtual void Yes()
        {
            ApplyCallback?.Invoke(this);
            OnRequestClose(true);
        }

        protected virtual void No()
        {
            OnRequestClose(false);
        }

        protected virtual void OK()
        {
            OnRequestClose(true);
        }

        protected virtual void Apply()
        {
            ApplyCallback?.Invoke(this);
        }

        protected virtual void Cancel()
        {
            OnRequestClose(false);
        }

        protected virtual bool CanYes() => true;

        protected virtual bool CanNo() => true;

        protected virtual bool CanOK() => true;

        protected virtual bool CanApply() => CanYes();

        protected virtual bool CanCancel() => true;
    }

    class DialogResultEventArgs : EventArgs
    {
        public bool? Result { get; set; }

        public DialogResultEventArgs(bool? result)
        {
            Result = result;
        }
    }
}
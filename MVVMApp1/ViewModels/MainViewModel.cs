using MVVMApp1.Dialogs;
using System.IO;

namespace MVVMApp1.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        readonly IDialog dialog;
        readonly IFileDialog fileDialog;
        int count;
        string fileName;

        public DelegateCommand<object> YesNoCommand { get; private set; }
        public DelegateCommand<object> AlertCommand { get; private set; }
        public DelegateCommand<object> BrowseCommand { get; private set; }
        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }
        public string FileName { get { return fileName; } set { fileName = value; OnPropertyChanged(); } }

        public MainViewModel(IDialog dialog, IFileDialog fileDialog)
        {
            this.dialog = dialog;
            this.fileDialog = fileDialog;
            YesNoCommand = new DelegateCommand<object>(YesNo);
            AlertCommand = new DelegateCommand<object>(Alert);
            BrowseCommand = new DelegateCommand<object>(Browse);
        }

        private void Browse(object owner)
        {
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialog.Title = "Open new file";
            if (fileDialog.ShowDialog(owner) is true)
            {
                FileName = fileDialog.FileName;
            }
        }

        private void YesNo(object owner)
        {
            var viewModel = new YesNoDialogViewModel("Question", "Can you see this?", YesNoUpdate);
            bool? dialogResult = dialog.ShowDialog(viewModel, owner);
        }

        private void YesNoUpdate(DialogViewModelBase viewModel)
        {
            Count++;
        }

        private void Alert(object owner)
        {
            var viewModel = new AlertDialogViewModel("Attention", "Alert");
            bool? dialogResult = dialog.ShowDialog(viewModel, owner);
        }
    }
}
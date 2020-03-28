using MVVMApp1.Dialogs;
using System.IO;

namespace MVVMApp1.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        readonly IDialogService dialogService;
        readonly IFileDialogService fileDialogService;
        int count;
        string fileName;

        public DelegateCommand<object> YesNoCommand { get; private set; }
        public DelegateCommand<object> AlertCommand { get; private set; }
        public DelegateCommand<object> BrowseCommand { get; private set; }
        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }
        public string FileName { get { return fileName; } set { fileName = value; OnPropertyChanged(); } }

        public MainViewModel(IDialogService dialogService, IFileDialogService fileDialogService)
        {
            this.dialogService = dialogService;
            this.fileDialogService = fileDialogService;
            YesNoCommand = new DelegateCommand<object>(YesNo);
            AlertCommand = new DelegateCommand<object>(Alert);
            BrowseCommand = new DelegateCommand<object>(Browse);
        }

        private void Browse(object owner)
        {
            fileDialogService.InitialDirectory = Directory.GetCurrentDirectory();
            fileDialogService.Title = "Open new file";
            if (fileDialogService.OpenFileDialog(owner) is true)
            {
                FileName = fileDialogService.FileName;
            }
        }

        private void YesNo(object owner)
        {
            var dialog = new YesNoDialogViewModel("Question", "Can you see this?", YesNoUpdate);
            bool? dialogResult = dialogService.OpenDialog(dialog, owner);
        }

        private void YesNoUpdate(DialogViewModelBase viewModel)
        {
            Count++;
        }

        private void Alert(object owner)
        {
            var dialog = new AlertDialogViewModel("Attention", "Alert");
            bool? dialogResult = dialogService.OpenDialog(dialog, owner);
        }
    }
}
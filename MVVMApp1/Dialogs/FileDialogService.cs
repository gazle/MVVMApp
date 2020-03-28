namespace MVVMApp1.Dialogs
{
    class FileDialogService<TFileDialog> : IFileDialogService where TFileDialog : IFileDialog, new()
    {
        readonly TFileDialog window;

        public string FileName { get => window.FileName; set => window.FileName = value; }
        public string InitialDirectory { get => window.InitialDirectory; set => window.InitialDirectory = value; }
        public string Filter { get => window.Filter; set => window.Filter = value; }
        public string DefaultExt { get => window.DefaultExt; set => window.DefaultExt = value; }
        public string Title { get => window.Title; set => window.Title = value; }

        public FileDialogService()
        {
            window = new TFileDialog();
        }

        public bool? OpenFileDialog(object owner)
        {
            //var window = (IFileDialog)Activator.CreateInstance(typeof(TFileDialog));
            bool? result = window.ShowDialog(owner);
            return result;
        }
    }
}
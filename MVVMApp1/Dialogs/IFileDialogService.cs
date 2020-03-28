namespace MVVMApp1.Dialogs
{
    interface IFileDialogService
    {
        string FileName { get; set; }
        string InitialDirectory { get; set; }
        string Filter { get; set; }
        string DefaultExt { get; set; }
        string Title { get; set; }

        bool? OpenFileDialog(object owner);
    }
}
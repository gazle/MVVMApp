namespace MVVMApp1.Dialogs
{
    interface IFileDialog
    {
        // Default file name
        string FileName { get; set; }
        string InitialDirectory { get; set; }
        // Filter = Description followed by | followed by the filter pattern
        // Use | as separator for different patterns
        // "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        // "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
        string Filter { get; set; }
        // Eg. ".txt"
        string DefaultExt { get; set; }
        // Title of the dialog
        string Title { get; set; }

        bool? ShowDialog(object owner);
    }
}
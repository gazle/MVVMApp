using Microsoft.Win32;
using MVVMApp1.Dialogs;
using MVVMApp1.ViewModels;
using MVVMApp1.Views;
using SimpleInjector;

namespace MVVMApp1.DI
{
    class IoC
    {
        public static IoC Instance { get; } = new IoC();

        readonly Container container = new Container();

        public MainViewModel MainViewModel => container.GetInstance<MainViewModel>();

        IoC()
        {
            container.Register<MainViewModel>();
            container.Register<OpenFileDialog>();
            container.Register<IDialog, DialogView>();
            container.Register<IFileDialog, FileDialogView>();
        }
    }
}
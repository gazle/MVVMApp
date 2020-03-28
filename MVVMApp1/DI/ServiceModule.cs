using MVVMApp1.Dialogs;
using MVVMApp1.Views;
using Ninject.Modules;

namespace MVVMApp1.DI
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService<DialogViewProxy>>();
            Bind<IFileDialogService>().To<FileDialogService<FileDialogView>>();
        }
    }
}
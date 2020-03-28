using MVVMApp1.ViewModels;
using Ninject;

namespace MVVMApp1.DI
{
    class ServiceLocator
    {
        private readonly IKernel kernel;

        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();

        public ServiceLocator()
        {
            kernel = new StandardKernel(new ServiceModule());
        }
    }
}
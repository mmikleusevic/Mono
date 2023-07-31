using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Mono.Service.Interfaces;
using Mono.Service.Services;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

namespace Mono.Service.Ninject
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;

        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IVehicleMakeService>().To<VehicleMakeService>();
            kernel.Bind<IVehicleModelService>().To<VehicleModelService>();
        }
    }
}

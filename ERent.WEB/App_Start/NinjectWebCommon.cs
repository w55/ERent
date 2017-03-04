[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ERent.WEB.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ERent.WEB.App_Start.NinjectWebCommon), "Stop")]

namespace ERent.WEB.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    //++
    using Ninject.Modules;
    using ERent.BLL.Infrastructure;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            // в проекте BLL также был создан модуль, который сопоставлял IUnitOfWork с EFUnitOfWork и передавал им название подключения. 
            // устанавливаем строку подключения: DefaultConnection
	    //
            var modules = new INinjectModule[] { new ServiceModule("DefaultConnection") };
            var kernel = new StandardKernel(modules);

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // регистрируем свой сопоставитель зависимостей:
            // интерфейс IAdvertService сопоставляется с классом AdvertService.
            //
            System.Web.Mvc.DependencyResolver.SetResolver(new ERent.WEB.Util.NinjectDependencyResolver(kernel));
        }        
    }
}

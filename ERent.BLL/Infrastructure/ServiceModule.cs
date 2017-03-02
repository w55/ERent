using Ninject.Modules;
using ERent.DAL.Interfaces;
using ERent.DAL.Repositories;

namespace ERent.BLL.Infrastructure
{
    /// <summary>
    /// Модуль Ninject, который служит для организации сопоставления зависимостей
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            // название подключения, которое в итоге будет определяться в файле web.config проекта
            connectionString = connection;
        }

        public override void Load()
        {
            // устанавливает использование EFUnitOfWork в качестве объекта IUnitOfWork
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}

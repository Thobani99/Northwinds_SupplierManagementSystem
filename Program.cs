using BusinessLogic;
using BusinessLogic.LogicInterfaces;
using DataLogic;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLogic.RepoInterfaces;
using RepositoryLogic.Repositories;

namespace NorthwindSupplierManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var serviceProvider = ConfigureServices();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = serviceProvider.GetRequiredService<Login>();
            Application.Run(loginForm);
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection(); 

            serviceCollection.AddSingleton<IDBConnection, DBConnection>();


            #region RepositoryLogic
            serviceCollection.AddSingleton<IManagerRepository, ManagerRepository>();
            serviceCollection.AddSingleton<ISuppliersRepository, SuppliersRepository>();
            serviceCollection.AddSingleton<IProductsRepository, ProductsRepository>();
            serviceCollection.AddSingleton<ICategoryRepository, CategoryRepository>();
            #endregion


            #region BusinessLogic
            serviceCollection.AddSingleton<IManagerLogic, ManagerLogic>();
            serviceCollection.AddSingleton<ISuppliersLogic, SuppliersLogic>();
            serviceCollection.AddSingleton<IProductsLogic, ProductsLogic>();
            #endregion

            #region UI's
            serviceCollection.AddTransient<Login>();
            serviceCollection.AddSingleton<DashBoard>();
            serviceCollection.AddSingleton<Suppliers>();
            serviceCollection.AddSingleton<ManageProducts>();
            serviceCollection.AddSingleton<ManageCategories>();
            #endregion 

            return serviceCollection.BuildServiceProvider();
        }
    }
}

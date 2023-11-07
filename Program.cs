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
            serviceCollection.AddSingleton<ICustomersRepository, CustomersRepository>();
            serviceCollection.AddSingleton<IOrdersRepository, OrdersRepository>();
            #endregion


            #region BusinessLogic
            serviceCollection.AddSingleton<IManagerLogic, ManagerLogic>();
            serviceCollection.AddSingleton<ISuppliersLogic, SuppliersLogic>();
            serviceCollection.AddSingleton<IProductsLogic, ProductsLogic>();
            serviceCollection.AddSingleton<ICustomersLogic, CustomersLogic>();
            serviceCollection.AddSingleton<IOrdersLogic, OrdersLogic>();
            #endregion

            #region UI's
            serviceCollection.AddTransient<Login>();
            serviceCollection.AddSingleton<DashBoard>();
            serviceCollection.AddSingleton<Suppliers>();
            serviceCollection.AddSingleton<ManageProducts>();
            serviceCollection.AddSingleton<ManageCategories>();
            serviceCollection.AddSingleton<CustomersList>();
            serviceCollection.AddSingleton<OrdersForm>();
            #endregion 

            return serviceCollection.BuildServiceProvider();
        }
    }
}

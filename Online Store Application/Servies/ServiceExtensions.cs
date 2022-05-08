using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    public static class ServiceExtensions
    {
        private static void RegisterService(IServiceCollection collection)
        {            
            collection.AddTransient<IRepository<Product>, ProductsList>();
            collection.AddTransient<IRepository<RegisteredUser>, UsersList>();

            collection.AddTransient<IUsersCollections, UsersCollections>();
            collection.AddTransient<IProductsCollections, ProductsCollections>();

            collection.AddTransient<IOrder, Order>();
            collection.AddTransient<IAccessInfo, Product>();
            collection.AddTransient<IRegisteredUser, RegisteredUser>();
            //collection.AddTransient<IRegisteredUser, Administrator>();


            collection.AddTransient<IMenu, MenuGuest>();
            //collection.AddTransient<IMenu, MenuRegisteredUser>();
            //collection.AddTransient<IMenu, MenuAdministrator>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ProductsCollections>();
            services.AddTransient<UsersCollections>();

            services.AddTransient<MenuGuest>();
            services.AddTransient<MenuRegisteredUser>();
            services.AddTransient<MenuAdministrator>();

            services.AddSingleton<MenuSwitcher>();

            services.AddTransient<MenuResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case Administrator:
                        return serviceProvider.GetService<MenuAdministrator>();
                    case RegisteredUser:
                        return serviceProvider.GetService<MenuRegisteredUser>();
                    default:
                        return serviceProvider.GetService<MenuGuest>();
                }
            });            
        }

        public static void BuildServices()
        {
            var services = new ServiceCollection();
            RegisterService(services);
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<MenuSwitcher>().RegisterUser(default);
        }
    }
}

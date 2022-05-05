using Microsoft.Extensions.DependencyInjection;
using System;

namespace Online_Store_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            #region junk
            //ProductsCollections productsCollections = new ProductsCollections();
            //UsersCollections usersCollections = new UsersCollections();

            //usersCollections.ChangeUserInformation();
            //MessageTable.ShowListMassage(productsCollections.ViewList());



            //ServiceExtensions.RegisterService();
            //Menu menu = new MenuGuest();
            //MenuSwitcher.Switch(menu); 
            #endregion
            ServiceExtensions.BuildServices();
        }
    }
}
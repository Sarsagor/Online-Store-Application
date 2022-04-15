using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Online_Store_Application
{
    class MenuGuest : IMenu
    {
        private IProductsCollections _productsCollections;
        private IUsersCollections _usersCollections;

        public MenuGuest(IProductsCollections productsCollections, IUsersCollections usersCollections)
        {
            _productsCollections = productsCollections;
            _usersCollections = usersCollections;
        }

        public void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.Search:
                    _productsCollections.Search();
                    break;
                case EnumCommands.SignIn:
                    _usersCollections.Login();
                    break;
                case EnumCommands.Registration:
                    _usersCollections.Registration();
                    break;
            }
        }

        public void MenuMessage()
        {
            Console.WriteLine("Поиска товара: 1 или Search");
            Console.WriteLine("Входа в свой аккаунт: 2 или SignIn");
            Console.WriteLine("Регестрации: 3 или Registration");
            Console.WriteLine("Выход/завершение: 20 или Exit");
        }
        public void Run()
        {
            MenuSwitcher.Switch(this);
        }
    }
}
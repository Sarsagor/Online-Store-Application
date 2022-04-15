using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Online_Store_Application
{
    class MenuGuest : Menu
    {
        private ILogin _login;
        private IRegistrator _registrator;

        public MenuGuest(ISearch search, ILogin login, IRegistrator registrator) 
            : base(search)
        {
            _login = login;
            _registrator = registrator;
        }

        public override void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.SignIn:
                    _login.Login();
                    break;
                case EnumCommands.Registration:
                    _registrator.Registration();
                    break;
                default:
                    base.SelectCommand(command);
                    break;
            }
        }

        public override void MenuMessage()
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
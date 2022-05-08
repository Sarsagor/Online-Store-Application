using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    public class MenuSwitcher
    {
        private readonly MenuResolver _menuResolver;

        private IMenu _menu;
        private User _user;

        public MenuSwitcher(MenuResolver menuResolver)
        {
            _menuResolver = menuResolver;
        }
        
        public void RegisterUser(User user)
        {
            _user = user;
            RegisterMenu();
        }
        private void RegisterMenu()
        {
            _menu = _menuResolver(_user);
            InteractionWithMenu();
        }
        private void InteractionWithMenu()
        {
            _menu.MenuMessage();
            do
            {
                Console.Write("\nВведите вашу команду: ");
                bool isCommand = Enum.TryParse(Console.ReadLine(), true, out EnumCommands command);
                if (isCommand)
                {
                    _menu.SelectCommand(command);
                }
                else
                {
                    Console.Write("\nВведенна не правильная команда. Повторите ввод: ");
                }
            }
            while (true);
        }
    }
}
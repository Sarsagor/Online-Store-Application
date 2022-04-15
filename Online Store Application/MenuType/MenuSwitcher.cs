using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    static class MenuSwitcher
    {
        public static void Switch(Menu menu)
        {
            menu.MenuMessage();
            do
            {
                Console.Write("\nВведите вашу команду: ");
                bool isCommand = Enum.TryParse(Console.ReadLine(), out EnumCommands command);
                if (isCommand)
                {                   
                    menu.SelectCommand(command);
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
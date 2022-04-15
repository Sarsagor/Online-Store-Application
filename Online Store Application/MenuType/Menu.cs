using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    abstract class Menu
    {
        private ISearch _search;
        public Menu(ISearch search)
        {
            _search = search;
        }

        public virtual void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.Search:
                    _search.Search();
                    break;
                case EnumCommands.Exit:
                    break;
                default:
                    Console.WriteLine("Такой команды нет. Попробуйте снова: ");
                    break;
            }
        }
        public abstract void MenuMessage();

    }
}
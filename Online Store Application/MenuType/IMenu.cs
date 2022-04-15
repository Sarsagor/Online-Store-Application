using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    internal interface IMenu
    {
        public void SelectCommand(EnumCommands command);
        public void MenuMessage();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    public delegate IMenu MenuResolver(User user);

    public interface IMenu
    {
        public void SelectCommand(EnumCommands command);
        public void MenuMessage();
    }
}

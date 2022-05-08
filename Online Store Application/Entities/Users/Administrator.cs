using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Online_Store_Application
{
    sealed class Administrator : RegisteredUser
    {
        public Administrator()
        {

        }
        public Administrator(string login, string password) 
            : base(login, password)
        {
        }
    }
}

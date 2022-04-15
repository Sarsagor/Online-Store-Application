using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application 
{
    internal class UsersList : IRepository<RegisteredUser>
    {
        private static List<RegisteredUser> users;
        public UsersList()
        {
            users = new List<RegisteredUser>()
            {
                new Administrator("admin","admin"),
                new Administrator("2","2"),
                new RegisteredUser("user","user"),
                new RegisteredUser("1","1")
            };
        }

        public void AddToRepository(RegisteredUser item)
        {
            users.Add(item);
        }

        public void RemoveFromRepository(RegisteredUser item)
        {
            users.Remove(item);
        }

        public List<RegisteredUser> GetRepository()
        {
            return users;
        }
    }
}

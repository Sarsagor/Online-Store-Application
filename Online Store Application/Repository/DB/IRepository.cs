using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    internal interface IRepository<T>
    {
        public void AddToRepository(T item);
        public void RemoveFromRepository(T item);
        public List<T> GetRepository();
    }
}

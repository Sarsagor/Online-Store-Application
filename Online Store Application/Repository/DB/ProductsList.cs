using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    internal class ProductsList : IRepository<Product>
    {    
        private List<Product> products;
        public ProductsList()
        {
            products = new List<Product>()
            {
                new Product("Coca-cola", Categories.drink, 5),
                new Product("Sprite", Categories.drink, 5),
                new Product("Pepsi", Categories.drink, 5),
                new Product("Fanta", Categories.drink, 5)
            };
        }

        public void AddToRepository(Product item)
        {
            products.Add(item);
        }

        public void RemoveFromRepository(Product item)
        {
            products.Remove(item);
        }

        public List<Product> GetRepository()
        {
            return products;
        }
    }
}

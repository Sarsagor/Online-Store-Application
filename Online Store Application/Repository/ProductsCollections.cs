using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    class ProductsCollections : IProductsCollections
    {
        public static List<Product> products;
        private IRepository<Product> _repository;

        #region Constructors
        public ProductsCollections(IRepository<Product> repository)
        {
            _repository = repository;
            GetRepository();
        }
        #endregion

        #region Interactions with Repository
        private void Add(Product product)
        {
            _repository.AddToRepository(product);
        }
        private void Remove(Product product)
        {
            _repository.RemoveFromRepository(product);
        }
        private void GetRepository()
        {
            products = _repository.GetRepository();
        }
        #endregion

        #region View all List<Product> and Search by name.
        //FIXME: Изменить способ отображения списка?
        public List<Product> ViewList()
        {
            return products;
            //UNDONE: messageTable.ShowMessage(products, "Назване:", "Категория:", "Цена:", "Описание:");
        }

        //FIXME: Расширить метод Search, добавить дополнительный поиск по критурию, сделать сортировку.
        public List<Product> Search()
        {
            Console.Write("Введите название продука: ");
            string name = Console.ReadLine();

            return products.Where(n => n.Name.ToLower().StartsWith(name.ToLower())).ToList();
            //UNDONE: старый код
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    var searchList = products.Where(n => n.Name.ToLower().StartsWith(name.ToLower())).ToList();
            //    if (searchList.Any())
            //    {
            //        messageTable.ShowMessage(searchList, "Назване:", "Категория:", "Цена:", "Описание:");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Таких продуктов нету.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Название введенно не корректно.");
            //}
        }
        #endregion

        #region AddProduct
        public void AddProduct()
        {
            string name = GetName();
            Categories category = GetCategory();
            decimal cost = GetCost();
            string description = GetDescription();

            if (string.IsNullOrWhiteSpace(description))
            {
                Add(new Product(name, category, cost));
            }
            else
            {
                Add(new Product(name, category, description, cost));
            }
        }
        
        private string GetName()
        {
            Console.Write("Название продукта: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть пустым или пробелами.");
                GetName();
            }
            return name;
        }
        private Categories GetCategory()
        {
            MessageTable.ShowCategories();
            Console.Write("Категория продукта: ");
            bool isCategory = Enum.TryParse(Console.ReadLine(), out Categories category);
            if (!isCategory)
            {
                Console.WriteLine("Такой категории нет.");
                GetCategory();
            }

            return category;
        }
        private decimal GetCost()
        {
            Console.Write("Ценна продукта: ");
            bool isCost = decimal.TryParse(Console.ReadLine(), out decimal cost);
            if (!isCost)
            {
                Console.WriteLine("Неверная ценна.");
                GetCost();
            }
            return cost;
        }
        private string GetDescription()
        {
            Console.Write("Описание продукта: ");
            string description = Console.ReadLine();

            return description;
        } 
        #endregion
    }
}

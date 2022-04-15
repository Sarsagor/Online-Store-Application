using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Online_Store_Application
{
    //UNDONE: Насколько плохо такое расположение?
    enum Categories
    {
        drink = 1,
        eat
    }
    
    class Product : IAccessInfo// IChangeProductInfo, IGetInfo
    {
        #region ProductInfo
        public string Name { get; private set; }
        public Categories Category { get; private set; }
        public decimal Cost { get; private set; }
        public string Description { get; private set; }
        #endregion

        #region Constructor
        public Product(string name, Categories category, decimal cost)
        {
            Name = name;
            Category = category;
            Cost = cost;
        }
        public Product(string name, Categories category, string description, decimal cost)
            : this(name, category, cost)
        {
            Description = description;
        }
        #endregion

        //FIXME: пока так - ChangeProductInfo()
        #region ChangeInfo
        public void ChangeInfo()
        {
            bool isDone = true;
            Console.WriteLine("\nДля изменения данных: ");
            Console.WriteLine("Название - Name or name");
            Console.WriteLine("Категория - Category or  cate");
            Console.WriteLine("Ценна - Cost or cost");
            Console.WriteLine("Описание - Description or desc");
            Console.WriteLine("Для выхода - Done or done\n");
            do
            {
                Console.Write("Ваша команда: ");
                switch (Console.ReadLine())
                {
                    case "Name" or "name":
                        ChangeName();
                        break;
                    case "Category" or "cate":
                        ChangeCategory();
                        break;
                    case "Cost" or "cost":
                        ChangeCost();
                        break;
                    case "Description" or "desc":
                        ChangeDescription();
                        break;
                    case "Done" or "done":
                        isDone = false;
                        break;
                    default:
                        isDone = true;
                        break;
                }
            } while (isDone);
        }
        private void ChangeName()
        {
            int minLength = 4;

            Console.Write("Введите название: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name) || name.Length >= minLength)
            {
                Name = name;
            }
            else
            {
                Console.WriteLine("Название слишком короткое или содержит одни пробелы.");
                ChangeName();
            }
        }
        private void ChangeCategory()
        {
            MessageTable.ShowCategories();

            Console.Write("Выберете категорию: ");
            bool isCategory = Enum.TryParse(Console.ReadLine(), out Categories category);
            if (isCategory)
            {
                Category = category;
            }
            else
            {
                Console.WriteLine("Такой категории нету.");
            }
        }
        private void ChangeCost()
        {
            Console.Write("Введите ценну: ");
            bool isCost = decimal.TryParse(Console.ReadLine(), out decimal cost);
            if (isCost || cost <= 0)
            {
                Cost = cost;
            }
            else
            {
                Console.WriteLine("Неверное занчение или ценна меньше 0.");
            }
        }
        private void ChangeDescription()
        {
            Console.Write("Введите описание: ");
            string description = Console.ReadLine();
            Description = description;
        } 
        #endregion

        public string[] GetInfo()
        {

            return new string[] { Name, Category.ToString(), Cost.ToString(), Description };
        }        
    }
}

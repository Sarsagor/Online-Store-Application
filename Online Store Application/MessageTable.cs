using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Online_Store_Application
{
    static class MessageTable
    {
        public static void ShowListMassage<T>(List<T> list)
        {
            var table = CreateTable(list);
            foreach (var item in list)
            {
                if (item is IGetInfo)
                {
                    table.AddRow((item as IGetInfo).GetInfo());
                }
            }

            Console.WriteLine(table);
        }

        private static ConsoleTable CreateTable<T>(List<T> list)
        {
            string[] content;

            switch (list)
            {
                case List<Order>:
                    content = new string[] { "Status", "Date of Creat" };
                    break;
                case List <Product>:
                    content = new string[] { "Name", "Category", "Cost", "Description" };
                    break;
                case List <RegisteredUser>:
                    content = new string[] { "Login", "Name", "Age", "Gender" };
                    break;
                default:
                    content = new string[] { "Данный тип не указан." };
                    break;
            }

            return new ConsoleTable(content);
        }

        //FIXME: В другой класс - ShowCategories()
        public static void ShowCategories()
        {
            foreach (var category in Enum.GetNames(typeof(Categories)))
            {
                Console.WriteLine(category.ToString());
            }
        }
    }
}

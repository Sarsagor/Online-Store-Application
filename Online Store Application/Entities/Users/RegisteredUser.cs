using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleTables;

namespace Online_Store_Application
{
    enum Gender
    {
        unknown,
        male,
        female
    }
    enum CommandChangeInfo
    {
        Name=1,
        Age,
        Gender,
        Balance
    }
    enum EnumOrdering
    {
        Order,
        Cancel
    }

    class RegisteredUser : User, IRegisteredUser
    {
        #region LoginInfo
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        #endregion

        #region PersonalInfo
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public Gender Gender { get; protected set; }
        public decimal Balance { get; protected set; }

        private Order currentOrder;
        public List<Order> Orders { get; protected set; }
        #endregion

        #region Constructor
        public RegisteredUser(string login, string password)
            : this(login, password, 0) { }
        public RegisteredUser(string login, string password, decimal balance)
        {
            Login = login;
            Password = password;

            Gender = Gender.unknown;
            Balance = balance;
            Orders = new List<Order>();
            //FIXME: FIX creating MENU object, MENU constructor have DI options // 1st: take MENU object from creating users
            //Menu = new MenuRegisteredUser();
        }
        #endregion

        //UNDONE: пересмоьреть.
        #region Other
        //protected ProductsCollections products = new ProductsCollections();
        public IMenu Menu { get; protected set; }
        public MessageTable message = new();
        #endregion

        //FIXME: Заменить case string на Enum - ChangePersonalInfo()???
        #region ChangeInfo
        public void ChangeInfo()
        {
            bool isDone = true;
            Console.WriteLine("Для изменения данных: ");
            Console.WriteLine("Имя - Name or name");
            Console.WriteLine("Возраст - Age or age");
            Console.WriteLine("Пол - Gender or gender");
            Console.WriteLine("Балланс - Balance or balance");
            Console.WriteLine("Для выхода - Done or done\n");
            do
            {
                Console.Write("Ваша команда: ");
                switch (Console.ReadLine())
                {
                    case "Name" or "name":
                        ChangeName();
                        break;
                    case "Age" or "age":
                        ChangeAge();
                        break;
                    case "Gender" or "gender":
                        ChangeGender();
                        break;
                    case "Balance" or "balance":
                        ChangeBalance();
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
        protected void ChangeName()
        {
            Console.Write("Введите желаемое имя: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Слишком коротки или содержит одни пробелы.");
                ChangeName();
            }
            Name = name;
        }

        protected void ChangeAge()
        {
            Console.Write("Введите сколько вам лет: ");
            bool getAge = int.TryParse(Console.ReadLine(), out int age);
            if (getAge)
            {
                if (age >= 0 && age <= 150)
                {
                    Age = age;
                    return;
                }
                else
                {
                    Console.WriteLine("Некоректнный возраст.");                    
                }
            }
            else
            {
                Console.WriteLine("Введенно не числое значение.");                
            }
            ChangeAge();
        }

        protected void ChangeGender()
        {
            Console.Write("Изменить вашу половую пренадлежность. Unknown - 0, Male - 1, Female - 2: ");

            bool getGedner = int.TryParse(Console.ReadLine(), out int numb);
            if (getGedner)
            {
                switch (numb)
                {
                    case 1:
                        Gender = Gender.unknown;
                        break;
                    case 2:
                        Gender = Gender.male;
                        break;
                    case 3:
                        Gender = Gender.female;
                        break;
                    default:
                        Console.WriteLine("Такой на данный момент нет.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введенно не числое значение.");
            }
        }

        protected void ChangeBalance()
        {
            Console.Write("Операция пополнения баланса, на сколько хотите поплонить балланс: ");
            bool getBalance = decimal.TryParse(Console.ReadLine(), out decimal balance);
            if (getBalance)
            {
                if (balance >= 0)
                {
                    
                    Console.WriteLine("Балланс успешно пополнен.");
                    return;
                }
                else
                {
                    Console.WriteLine("Ну не настолько же плохо все, но как скажите.");
                }
                Balance += balance;
            }
            else
            {
                Console.WriteLine("Введенно не числое значение.");
                ChangeBalance();
            }
        }
        #endregion

        //FIXME: нужен ли способ вывода - GetPersonalInfo()
        public string[] GetInfo()
        {
            return new string[] {Login, Name, Age.ToString(), Gender.ToString()};
        }

        //FIXME: пока так - ChangeOrderStatus()
        public virtual void ChangeOrderStatus()
        {
            OrdersHistoryAndStatus();

            Console.Write("Выбере заказ: ");
            bool isNumb = int.TryParse(Console.ReadLine(), out int numb);
            if (isNumb || Orders.Count >= numb)
            {
                Orders[numb].ChangeStatus(this);
            }
            else
            {
                Console.WriteLine("Ввели не корректное значение.");
            }
        }
        //FIXME: пока так - OrderingOrCancellation()
        public void OrderingOrCancellation()
        {
            if (currentOrder != null || currentOrder.Products.Any())
            {
                bool isCommand = Enum.TryParse(Console.ReadLine(), out EnumOrdering command);
                if (isCommand)
                {
                    switch (command)
                    {
                        case EnumOrdering.Order:
                            Orders.Add(currentOrder);
                            Console.WriteLine("Заказ сделан.");
                            break;
                        case EnumOrdering.Cancel:
                            currentOrder = null;
                            Console.WriteLine("Заказ отклонен.");
                            break;
                        default:
                            Console.WriteLine("Что то пошло не так.");
                            break;
                    }
                }
                else
                {
                    Console.Write("\nВведенна не правильная команда.");
                }
            }
            else
            {
                Console.WriteLine("У вас нет текущего заказа или он пуст.");
            }
        }





        //FIXME: способ отображения списка, возращать List??? - OrdersHistoryAndStatus().
        public List<Order> OrdersHistoryAndStatus()
        {
            return Orders;
            //message.ShowMessage(Orders, "№:", "Статус:", "Дата заказа:", "Количество товаров:");
        }

        //FIXME: SignOut()
        public void SignOut()
        {
            //MenuSwitcher.Switch(new MenuGuest());
        }
    }
}
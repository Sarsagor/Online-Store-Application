using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    class UsersCollections : IUsersCollections
    {
        private static List<RegisteredUser> users;
        private readonly IRepository<RegisteredUser> _repository;
        private readonly MenuSwitcher _menuSwitcher;

        #region Constructor
        public UsersCollections(IRepository<RegisteredUser> repository, MenuSwitcher menuSwitcher)
        {
            _repository = repository;
            _menuSwitcher = menuSwitcher;
            GetRepository();
        } 
        #endregion

        #region Interactions with Repository
        private void Add(RegisteredUser registeredUser)
        {

            users.Add(registeredUser);
        }
        private void Remove(RegisteredUser user)
        {
            users.Remove(user);
        }

        private void GetRepository()
        {
            users = _repository.GetRepository();
        }
        #endregion

        #region AnotherClass?
        private (string, string) InputLoginAndPassword()
        {
            Console.Write("Придумайте и введите логин: ");
            string login = CheckValue();

            Console.Write("Придумайте и введите пароль: ");
            string password = CheckValue();

            return (login, password);
        }
        private string CheckValue()
        {
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Слишком коротки или содержит одни пробелы.");
                CheckValue();
            }
            return value;
        }
        #endregion

        public void Registration()
        {
            var (login, password) = InputLoginAndPassword();

            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    Console.WriteLine("Такой пользователь уже есть.");
                    return;
                }
            }
            Add(new RegisteredUser(login, password));
        }

        //FIXME: Изменить способ перехода пользователя.
        public void Login()
        {
            var (login, password) = InputLoginAndPassword();

            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    if (user.Password == password)
                    {
                        _menuSwitcher.RegisterMenu(user);
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль");
                        return;
                    }
                }
            }
            Console.WriteLine("Неверный логин.");
        }         

        public void ChangeUserInformation()
        {
            //UNDONE:Метод показа пользователей.
            //MessageTable messageTable = new MessageTable();
            //FIXME: messageTable.ShowMessage(users, "Login", "Name", "Age", "Пол");
            MessageTable.ShowListMassage(GetAllUsers());

            Console.Write("Выберите пользователя: ");
            bool isNumb = int.TryParse(Console.ReadLine(), out int numb);
            if (isNumb || users.Count >= numb)
            {
                users[numb].ChangeInfo();
            }
            else
            {
                Console.WriteLine("Ввели не корректное значение или такого пользователя нет.");
            }
        }

        private List<RegisteredUser> GetAllUsers()
        {
            return users.OfType<RegisteredUser>().ToList();
            
        }
    }
}
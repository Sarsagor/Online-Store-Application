using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    class MenuRegisteredUser : IMenu
    {
        protected IProductsCollections _productsCollections;
        protected IUsersCollections _usersCollections;
        protected IOrder _order;
        protected IRegisteredUser _registeredUser;

        public MenuRegisteredUser(IProductsCollections productsCollections, IUsersCollections usersCollections,
            IOrder order, IRegisteredUser registeredUser)
        {
            _productsCollections = productsCollections;
            _usersCollections = usersCollections;
            _order = order;
            _registeredUser = registeredUser;
        }

        public virtual void MenuMessage()
        {
            Console.Clear();
            Console.WriteLine("Поиск товара: 1 или Search ");
            Console.WriteLine("Просмотр всех продуктов: 2 или ViewList");
            Console.WriteLine("Создание нового заказа: 3 или CreatOrder");
            Console.WriteLine("Потдверждение или отмена заказа: 4 или OrderOrCancel");
            Console.WriteLine("Изменить статус заказа: 5 или ChangeStatus");
            Console.WriteLine("История заказов: 6 или OrdersHistory");
            Console.WriteLine("Изменение персональных данных: 7 или ChangePersonalInfo");
            Console.WriteLine("Выход с аккаунта: 8 или Logout");
        }
        public virtual void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.Search:
                    _productsCollections.Search();
                    break;
                case EnumCommands.ViewList:
                    _productsCollections.ViewList();
                    break;
                case EnumCommands.CreatOrder:
                    _order.CreatOrder();
                    break;
                case EnumCommands.OrderOrCancel:
                    _registeredUser.OrderingOrCancellation();
                    break;
                case EnumCommands.ChangeStatus:
                    _order.ChangeStatus(new RegisteredUser("1","1")/*UNDONE*/);
                    break;
                case EnumCommands.OrdersHistory:
                    _registeredUser.OrdersHistoryAndStatus();
                    break;
                case EnumCommands.ChangePersonalInfo:
                    _registeredUser.ChangeInfo();
                    break;
                case EnumCommands.Logout:
                    _registeredUser.SignOut();
                    break;
            }
        }
    }
}
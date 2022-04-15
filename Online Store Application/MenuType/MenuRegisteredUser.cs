using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    class MenuRegisteredUser : Menu
    {
        protected IViewList _viewList;
        protected ICreatOrder _creatOrder;
        protected IOrderOrCancel _orderOrCancel;
        protected IChangeStatus _changeStatus;
        protected IOrdersHistory _ordersHistory;
        protected IAccessInfo _accessInfo;
        protected ILogOut _logOut;

        public MenuRegisteredUser(ISearch search, IViewList viewList, ICreatOrder creatOrder, 
            IOrderOrCancel orderOrCancel, IChangeStatus changeStatus, IOrdersHistory ordersHistory,
            IAccessInfo accessInfo, ILogOut logOut) 
            : base(search)
        {
            _viewList = viewList;
            _creatOrder = creatOrder;
            _orderOrCancel = orderOrCancel;
            _changeStatus = changeStatus;
            _ordersHistory = ordersHistory;
            _accessInfo = accessInfo;
            _logOut = logOut;
        }

        public override void MenuMessage()
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
        public override void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.ViewList:
                    _viewList.ViewList();
                    break;
                case EnumCommands.CreatOrder:
                    _creatOrder.CreatOrder();
                    break;
                case EnumCommands.OrderOrCancel:
                    _orderOrCancel.OrderingOrCancellation();
                    break;
                case EnumCommands.ChangeStatus:
                    _changeStatus.ChangeStatus(new RegisteredUser("1","1")/*UNDONE*/);
                    break;
                case EnumCommands.OrdersHistory:
                    _ordersHistory.OrdersHistoryAndStatus();
                    break;
                case EnumCommands.ChangePersonalInfo:
                    _accessInfo.ChangeInfo();
                    break;
                case EnumCommands.Logout:
                    _logOut.SignOut();
                    break;
                default:
                    base.SelectCommand(command);
                    break;
            }
        }
    }
}
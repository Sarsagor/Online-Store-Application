using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    sealed class MenuAdministrator : MenuRegisteredUser
    {
        private IAddProduct _addProduct;
        private IChangeUserInformation _changeUserInformation;
        public MenuAdministrator(ISearch search, IViewList viewList, ICreatOrder creatOrder, 
            IOrderOrCancel orderOrCancel, IChangeStatus changeStatus, IOrdersHistory ordersHistory,
            IAccessInfo accessInfo, ILogOut logOut, IAddProduct addProduct,IChangeUserInformation changeUserInformation) 
            : base(search, viewList, creatOrder, orderOrCancel, changeStatus, 
                  ordersHistory, accessInfo, logOut)
        {
            _addProduct = addProduct;
            _changeUserInformation = changeUserInformation;
        }

        public sealed override void MenuMessage()
        {
            base.MenuMessage();
            Console.WriteLine("Добавить новый продукт: 9 или AddNewProduct");
            Console.WriteLine("Изменить продукт: 10 или ChangeProductInfo");
            Console.WriteLine("Изменить информацию о пользоватее: 11 или ChangeUserInfo");
        }
        public sealed override void SelectCommand(EnumCommands command)
        {
            switch (command)
            {
                case EnumCommands.AddNewProduct:
                    _addProduct.AddProduct();
                    break;
                case EnumCommands.ChangeProductInfo:
                    _accessInfo.ChangeInfo(); //FIXME: именно продукт.
                    break;
                case EnumCommands.ChangeUserInfo:
                    _changeUserInformation.ChangeUserInformation();
                    break;
                default:
                    base.SelectCommand(command);
                    break;
            }            
        }        
    }
}
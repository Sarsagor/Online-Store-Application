using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    sealed class MenuAdministrator : MenuRegisteredUser
    {
        private readonly IAccessInfo _accessInfo;
        public MenuAdministrator(IProductsCollections productsCollections, IUsersCollections usersCollections,
            IOrder order, IRegisteredUser registeredUser, IAccessInfo accessInfo) 
            :base(productsCollections, usersCollections, order, registeredUser)
        {
            _accessInfo = accessInfo;
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
                    _productsCollections.AddProduct();
                    break;
                case EnumCommands.ChangeProductInfo:
                    _accessInfo.ChangeInfo();
                    break;
                case EnumCommands.ChangeUserInfo:
                    _usersCollections.ChangeUserInformation();
                    break;
                default:
                    base.SelectCommand(command);
                    break;
            }            
        }        
    }
}
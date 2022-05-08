using System;

namespace Online_Store_Application
{
    class MenuToUser //посредник
    {
        IMenu menu; // как сюда присвоить не одно меню, а несколько??? и можно ли вообще
        public MenuToUser(IMenu menu) // IEnumerable???
        {
            this.menu = menu;
        }
        public void DoSomeThink(User user)
        {
            IMenu menuToSwitch;
            //взависимости от пользователя вызывается нужное меню
            switch (user)
            {
                case User2:
                    menuToSwitch = menu as Menu2;
                    break;
                default:
                    menuToSwitch = menu as MenuGuest;
                    break;
                    //another case
            }
            //MenuSwitcher.Switch(menuToSwitch);
        }
    }

    class User2 : User
    {
        MenuToUser mu; // после регестрации в сервисе его делать не нужно будет, но как пример.
        public User2()
        {
            mu = new MenuToUser(new Menu2());
        }
        public void SwitchMenu()
        {
            mu.DoSomeThink(this);
        }
    }
    class Menu2 : IMenu
    {
        public void MenuMessage()
        {
            throw new NotImplementedException();
        }

        public void SelectCommand(EnumCommands command)
        {
            throw new NotImplementedException();
        }
    }
}

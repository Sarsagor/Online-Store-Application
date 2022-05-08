using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    public enum EnumCommands
    {
        Search = 1,
        SignIn,        
        Registration,        
        ViewList = 2,
        CreatOrder,
        OrderOrCancel,
        ChangeStatus,
        OrdersHistory,
        ChangePersonalInfo,
        Logout,
        AddNewProduct,
        ChangeProductInfo,        
        ChangeUserInfo,
        Exit = 20
    }
}
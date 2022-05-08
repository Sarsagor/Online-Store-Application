using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Application
{
    enum OrderStatus
    {
        New,
        Received,
        CancledByUser,
        PaymentReceived = 2,
        Sent,
        Completed,
        CancledByAdmin
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Online_Store_Application
{
    //UNDONE: Насколько плохо такое расположение.
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

    class Order : IOrder
    {
        #region OrderInfo
        public OrderStatus Status { get; private set; }
        public DateTime DateCreate { get; private set; }
        public List<Product> Products { get; private set; }
        #endregion

        public Order()
        {
            Status = OrderStatus.New;
            Products = new List<Product>();
            DateCreate = DateTime.Now;
        }

        #region ChangeStatus
        public void ChangeStatus(RegisteredUser user)
        {
            ShowOrdersStatus(user);
            OrderStatus status = GetOrderStatus();

            if(Status == status)
            {
                Console.WriteLine("Новый статус такой же как текущий.");
            }
            else if (IsOrderedStatus(status, user))
            {
                Status = status;
                Console.WriteLine("Статус изменен.");
            }
            else
            {
                Console.WriteLine("Установить статус не удалось.");
            }
        }

        private void ShowOrdersStatus(RegisteredUser user)
        {
            Console.WriteLine("Выберете статус: ");
            Console.WriteLine("Recive or 1");
            switch (user)
            {
                case Administrator:
                    Console.WriteLine("PaymentReceived - 2");
                    Console.WriteLine("Sent - 3");
                    Console.WriteLine("Completed - 4");
                    Console.WriteLine("Cancle - 5");
                    break;

                case RegisteredUser:
                    Console.WriteLine("Cancle or 2");
                    break;
            }
        }
        private OrderStatus GetOrderStatus()
        {
            Console.Write("\nВыберите новый статус: ");
            bool isStatus = Enum.TryParse(Console.ReadLine(), out OrderStatus status);
            if (!isStatus)
            {
                Console.WriteLine("Такой статус отсутствует.");
                GetOrderStatus();
            }
            return status;
        }
        private bool IsOrderedStatus(OrderStatus status, RegisteredUser user)
        {
            bool isStatus = true;
            switch (status, user)
            {
                case (OrderStatus.PaymentReceived, Administrator):
                    return isStatus;
                case (OrderStatus.Sent, Administrator):
                    return isStatus;
                case (OrderStatus.Completed, Administrator):
                    return isStatus;
                case (OrderStatus.CancledByAdmin, Administrator):
                    goto Received;

                case (OrderStatus.Received, RegisteredUser):
                    if (Status == OrderStatus.CancledByUser || Status == OrderStatus.CancledByAdmin)
                    {
                        return !isStatus;
                    }
                    return isStatus;
                case (OrderStatus.CancledByUser, RegisteredUser):
                    Received:
                    if (Status == OrderStatus.Received)
                    {
                        return !isStatus;
                    }
                    return isStatus;
                default:
                    return !isStatus;
            }
        } 
        #endregion

        public string[] GetInfo()
        {
           return new string[] { Status.ToString(), DateCreate.ToString() };
        }



        //FIXME: не указан/неизвестен способ показала товара - CreatOrder
        public void CreatOrder()
        {
            bool isStillAdded = false;
            do
            {
                Console.Write("Введите номер товара: ");
                bool isNumb = int.TryParse(Console.ReadLine(), out int numb);
                if (isNumb)
                {
                    //Products.Add(Сюда продукт для добавления);
                    YorN:
                    Console.Write("Добавить еще Y/N: ");                    
                    switch (Console.ReadLine())
                    {
                        case "Y" or "y":
                            CreatOrder();
                            break;
                        case "N" or "n":
                            isStillAdded = false;
                            break;
                        default:
                            Console.WriteLine("Не корректный ввод.");
                            goto YorN;;
                    }
                }
                else
                {
                    Console.WriteLine("Ввели не корректное значение.");
                }
            } while (isStillAdded);
        }
    }
}

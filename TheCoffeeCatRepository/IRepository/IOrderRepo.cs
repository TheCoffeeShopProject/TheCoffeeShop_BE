using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
   public interface IOrderRepo
    {
        bool ChangeOrderStatus(Order order);


        List<Order> GetOrders();
        void AddNew(Order order);


        Order GetOrderById(Guid id);

        void UpdateOrder(Order order);

        
    }
}

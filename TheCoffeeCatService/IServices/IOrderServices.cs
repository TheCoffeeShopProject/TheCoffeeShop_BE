using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface IOrderServices
    {

        bool ChangeOrderStatus(Order order);


        List<Order> GetOrders();
        void AddNew(Order order);


        Order GetOrderById(Guid id);

        void UpdateOrder(Order order);
    }
}

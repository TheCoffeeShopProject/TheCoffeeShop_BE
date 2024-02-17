using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class OrderServices : IOrderServices
    {

        private IOrderRepo _order;

        public OrderServices(IOrderRepo order)
        {
            _order = order; 
            
        }
        public void AddNew(Order order)
        {
            _order.AddNew(order);
        }

        public bool ChangeOrderStatus(Order order)
        {
           return  _order.ChangeOrderStatus(order); 
        }

        public Order GetOrderById(Guid id)
        {
            return _order.GetOrderById(id);
        }

        public List<Order> GetOrders()
        {
          return _order.GetOrders();
        }

        public void UpdateOrder(Order order)
        {
           _order.UpdateOrder(order);
        }
    }
}

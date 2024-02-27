using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private OrderDAO dao;

        public OrderRepo()
        {
            dao = new OrderDAO();
        }

      
        public void AddNew(Order order)
        {
           dao.AddNew(order);
        }

        public bool ChangeOrderStatus(Order order)
        {
           return dao.ChangeOrderStatus(order); 
        }

        public Order GetOrderById(Guid id)
        {
            return dao.GetOrderByID(id);
        }

        public List<Order> GetOrders()
        {
            return dao.GetAllOrder();
        }

        public void UpdateOrder(Order order)
        {
          dao.UpdateOrder(order);
        }
    }
}

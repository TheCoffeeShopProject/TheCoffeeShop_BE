using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }


        }

        public List<Order> GetAllOrder()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Orders.Include(c=>c.Table).ToList();
        }

        public bool AddNew(Order order)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Orders.SingleOrDefault(c => c.OrderID== order.OrderID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return true;

            }
        }

        public bool UpdateOrder(Order order)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Orders.SingleOrDefault(c => c.OrderID  == order.OrderID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(order);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ChangeOrderStatus(Order order)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Orders.SingleOrDefault(c => c.OrderID == order.OrderID);



            if (a == null)
            {
                return false;
            }
            else
            {
                a.Status = false;
                _context.Entry(a).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

        public Order GetOrderByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Orders.SingleOrDefault(a => a.OrderID == id);
        }

    }
}

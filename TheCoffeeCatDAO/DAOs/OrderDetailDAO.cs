using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject;
using Microsoft.EntityFrameworkCore;

namespace TheCoffeeCatDAO.DAOs
{
    public class OrderDetailDAO
    {

        private static OrderDetailDAO instance;

        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }


          public bool AddNew(OrderDetail orderdetail)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.OrderDetails.SingleOrDefault(c => c.OrderDeatailID == orderdetail.OrderDeatailID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.OrderDetails.Add(orderdetail);
                _context.SaveChanges();
                return true;

            }
        }

        public void DeleteOrderDeatail(OrderDetail orderdetail)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.OrderDetails.FirstOrDefault(a =>a.OrderDeatailID == orderdetail.OrderDeatailID);
            _context.OrderDetails.Remove(a);
            _context.SaveChanges();
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetailByOrderId(Order order)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.OrderDetails.SingleOrDefault(c=> c.OrderID == order.OrderID);
        }



    }


}


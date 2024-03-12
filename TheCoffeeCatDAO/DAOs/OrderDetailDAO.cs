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
                //var menu = _context.Menus.SingleOrDefault(m=>m.MenuID == orderdetail.MenuID);
                //if(menu == null)
                //{
                //    return false;
                //}
             
                //orderdetail.Menu = menu;

                //var order = _context.Orders.SingleOrDefault(m=>m.OrderID == orderdetail.OrderID);
                //if(order == null)
                //{
                //    return false;
                //}
                //orderdetail.Order = order;

                //var subcription = _context.Subscriptions.SingleOrDefault(m => m.SubscriptionID == orderdetail.SubscriptionID);
                //if (subcription == null)
                //{
                //    return false;
                //}
                //orderdetail.Subscription = subcription;


                _context.OrderDetails.Add(orderdetail);
                _context.SaveChanges();

                return true;

            }
        }

       

        public void DeleteOrderDeatail(OrderDetail orderdetail)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.OrderDetails.FirstOrDefault(a =>a.OrderDeatailID == orderdetail.OrderDeatailID);
            if (a != null)
            {
                a.Menu = null;
                a.Order = null;
            }
            _context.OrderDetails.Remove(a);
            _context.SaveChanges();
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetail(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.OrderDetails.SingleOrDefault(a => a.OrderDeatailID.Equals(id) );
            
        }



    }


}


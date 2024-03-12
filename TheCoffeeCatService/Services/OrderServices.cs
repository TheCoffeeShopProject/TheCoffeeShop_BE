using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class OrderServices : IOrderServices
    {

        private IOrderRepo _order;
        private IOrderDetailRepo _orderDetail;

        public OrderServices(IOrderRepo order, IOrderDetailRepo orderDetail)
        {
            _order = order;
            _orderDetail = orderDetail;
        }

        public void AddNewOrder(Order order)
        {
            _order.AddNew(order);
        }

        public bool AddNewOrderByListOrderDetail(List<OrderDetail> list, Guid? CPID, Guid StaffID,Guid? SubcriptionID)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    double totalPrice = 0;
                    int totalItem = 0;


                    foreach (OrderDetail detail in list)
                    {
                        totalPrice += detail.Amount * detail.Quantity;
                        totalItem += detail.Quantity;

                    }

                    Order order = new Order
                    {
                        OrderID = Guid.NewGuid(),
                        CreateTime = DateTime.Now,
                        TotalPrice = totalPrice,
                        TotalItem = totalItem,
                        StaffID = StaffID,
                        CPID = CPID,
                    };
                    _order.AddNew(order);
                    foreach (OrderDetail detail in list)
                    {
                        detail.OrderDeatailID = Guid.NewGuid();
                        detail.OrderID = order.OrderID;
                        detail.SubscriptionID = SubcriptionID;
                        _orderDetail.AddNew(detail);
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return false;
                }
            }
            
        }

        public bool ChangeOrderStatus(Order order)
        {
            return _order.ChangeOrderStatus(order);
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

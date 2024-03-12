using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private IOrderDetailRepo _orderdetail;
        public OrderDetailServices(IOrderDetailRepo orderdetail)
        {
            _orderdetail = orderdetail;
        }
        public void AddNew(OrderDetail orderdetail)
        {
            _orderdetail.AddNew(orderdetail);
        }

        public void Delete(OrderDetail orderdetail)
        {
            _orderdetail.Delete(orderdetail);
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            return _orderdetail.GetAllOrderDetail();
        }

        public OrderDetail GetOrderDetail(Guid id)
        {
           return _orderdetail.GetOrderDetail(id);
        }
    }
}

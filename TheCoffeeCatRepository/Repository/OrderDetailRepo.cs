using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private OrderDetailDAO dao;
        public OrderDetailRepo()
        {
            dao = new OrderDetailDAO();
        }
        public void AddNew(TheCoffeeCatBusinessObject.BusinessObject.OrderDetail orderdetail)
        {
            dao.AddNew(orderdetail);
        }

        public void Delete(TheCoffeeCatBusinessObject.BusinessObject.OrderDetail orderdetail)
        {
            dao.DeleteOrderDeatail(orderdetail);
        }

        public List<OrderDetail> GetAllOrder()
        {
            return dao.GetAllOrderDetail();
        }

        public List<OrderDetail> GetAllOrderDetail()
        {
            return dao.GetAllOrderDetail();
        }

        public OrderDetail GetOrderDetail(Guid id)
        {
          return dao.GetOrderDetail(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatService.IServices
{
    public interface IOrderDetailServices
    {
        void AddNew(OrderDetail orderdetail);
        void Delete(OrderDetail orderdetail);
        List<OrderDetail> GetAllOrderDetail();
        OrderDetail GetOrderDetail(Guid id);
    }
}

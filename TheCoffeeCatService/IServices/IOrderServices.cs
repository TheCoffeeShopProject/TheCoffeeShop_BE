using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;

namespace TheCoffeeCatService.IServices
{
    public interface IOrderServices
    {

        bool ChangeOrderStatus(Order order);

        List<object> GetMonthlyTotalPrices();
        List<Order> GetOrders();
        void AddNewOrder(Order order);
        bool AddNewOrderByListOrderDetail(List<OrderDetail> list, Guid? CPID, Guid StaffID);
        double CalculateTotalOrderPrice();
        int CalculateTotalItems();
        Order GetOrderById(Guid id);

        void UpdateOrder(Order order);
    }
}

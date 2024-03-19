using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.DTO.Request;

namespace TheCoffeeCatDAO.DAOs
{
    public class PaymentInformationModel
    {
        public string OrderType { get; set; }
        public DateTime CreateTime { get; set; }
        public double Amount { get; set; }
        public float TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public int TotalDiscount { get; set; }
        public bool status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid UserID { get; set; }
        public Guid tableID { get; set; }
        public Guid CPID { get; set; }
        public Guid StaffID { get; set; }
        public List<OrderDetailCreateDTO>? orderDetails { get; set; }
    }
}

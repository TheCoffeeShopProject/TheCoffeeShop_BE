using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime CreateTime { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public float TotalDiscount { get; set; }
        public bool Status { get; set; }
        public Guid CustomerID { get; set; }
        public Guid StaffID { get; set; }
        public Staff Staff { get; set; }
        public Guid? CPID { get; set; }
        public CustomerPackage CustomerPackage { get; set; }

        public Guid? TableID { get; set; }
        public Table Table { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class OrderCreateDTO
    {
        public Guid OrderID { get; set; }
        public DateTime CreateTime { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItem { get; set; }
        public float TotalDiscount { get; set; }
        public bool Status { get; set; }

        public Guid StaffID { get; set; }
     
        public Guid? CPID { get; set; }
       
        public Guid? TableID { get; set; }
    }
}

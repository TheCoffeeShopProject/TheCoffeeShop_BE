using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class OrderDetailCreateDTO
    {

        public int Quantity { get; set; }

        public float Amount { get; set; }
        public Guid? MenuID { get; set; }
        public Guid? OrderID { get; set; }
        public Guid? SubscriptionID { get; set; } 
    }
}

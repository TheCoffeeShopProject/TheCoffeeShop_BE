using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public class OrderDetail
    {
        public Guid OrderDeatailID { get; set; }
       
        public int Quantity { get; set; }

        public float Amount { get; set; }
        public Guid MenuID { get; set; }
        public Menu Menu { get; set; }

        public Guid OrderID { get; set; }
        public Order Order { get; set; }

    }
}

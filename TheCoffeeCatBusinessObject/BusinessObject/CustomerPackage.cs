using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
   public class CustomerPackage
    {
        public Guid CPID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public  Guid CustomerID { get; set; }
        public Customer Customer { get; set; }

        public Guid SubscriptionID { get; set; }

        public Subscription Subscription { get; set; }
    }
}

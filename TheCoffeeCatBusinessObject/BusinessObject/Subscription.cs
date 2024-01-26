using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject
{
    public class Subscription
    {
       
        public Guid SubscriptionID { get; set; }
       
        public string Name { get; set; }
       
        public bool Status { get; set; }
       
        public float DiscountPercent { get; set; }
       
        public List<CustomerPackage> CustomerPackages { get; set; }


     }
}

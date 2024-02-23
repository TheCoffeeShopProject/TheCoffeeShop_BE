using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class SubscriptionDTO
    {

        public string Name { get; set; }

        public bool Status { get; set; }

        public float DiscountPercent { get; set; }

        public double Price { get; set; }

    }
}

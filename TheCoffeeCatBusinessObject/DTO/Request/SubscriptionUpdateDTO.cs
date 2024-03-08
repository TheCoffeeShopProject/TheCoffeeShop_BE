using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class SubscriptionUpdateDTO
    {

        public string? Name { get; set; }

        public bool? Status { get; set; }

        public float? DiscountPercent { get; set; }

        public double? Price { get; set; }
    }
}

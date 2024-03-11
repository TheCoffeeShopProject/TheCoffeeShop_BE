using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class SubscriptionResponseDTO
    {
        public Guid SubscriptionID { get; set; }

        public string? Name { get; set; }

        public float? DiscountPercent { get; set; }

        public double? Price { get; set; }

    }
}

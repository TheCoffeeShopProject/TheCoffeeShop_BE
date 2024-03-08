using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CustomerPackageUpdateDTO
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid? CustomerID { get; set; }
        public Guid? SubscriptionID { get; set; }
    }
}

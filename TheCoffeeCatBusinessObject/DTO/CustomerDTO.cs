using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class CustomerDTO
    {
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }
        public Guid AccountID { get; set; }
    }
}

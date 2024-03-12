using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CustomerUpdateDTO
    {

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }
        public Guid? AccountID { get; set; }
    }
}

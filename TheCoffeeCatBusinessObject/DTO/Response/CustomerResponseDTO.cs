using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class CustomerResponseDTO
    {
        public Guid? CustomerID { get; set; }
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }
        public Guid? AccountID { get; set; }
    }
}

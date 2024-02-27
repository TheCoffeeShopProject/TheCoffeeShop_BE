using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CoffeeCreateDTO
    {

        public string CoffeeName { get; set; }
        public string OpenTime { get; set; }

        public string CloseTime { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class CoffeeResponseDTO
    {
        public string? CoffeeName { get; set; }
        public string? OpenTime { get; set; }

        public string? CloseTime { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }


        public string? Image { get; set; }
    }
}

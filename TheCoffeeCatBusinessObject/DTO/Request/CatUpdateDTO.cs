using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
   public class CatUpdateDTO
    {
        public int? Age { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }

        public Guid? CoffeeID { get; set; }
        public bool? Status { get; set; }

    }
}

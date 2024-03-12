using Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Collections.Specialized.BitVector32;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
   public class CatUpdateDTO
    {
        public string? CatName { get; set; }
        public int? Age { get; set; }
        
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }

        public Guid? CoffeeID { get; set; }
        public bool? Status { get; set; }

    }
}


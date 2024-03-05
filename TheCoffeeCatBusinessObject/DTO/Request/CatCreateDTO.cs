using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CatCreateDTO
    {
        public string CatName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public IFormFile Image { get; set; }
        public Guid CoffeeID { get; set; }
    }
}

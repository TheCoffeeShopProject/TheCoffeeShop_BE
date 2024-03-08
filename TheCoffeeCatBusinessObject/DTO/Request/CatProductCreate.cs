using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CatProductCreate
    {
        public string CatProductName { get; set; }
        public string CatProductType { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public IFormFile Image { get; set; }
    }
}

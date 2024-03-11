using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Response
{
    public class CatProductResponse
    {
        public Guid? CatProductID { get; set; }
        public string? CatProductName { get; set; }
        public string? CatProductType { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
    }
}

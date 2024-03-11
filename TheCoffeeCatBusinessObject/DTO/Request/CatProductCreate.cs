using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CatProductCreate
    {
        [Required(ErrorMessage = "Cat product name is required.")]
        public string CatProductName { get; set; }
        [Required(ErrorMessage = "Type of cat product is required.")]
        public string CatProductType { get; set; }
        [Required(ErrorMessage = "Price of cat product is required.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile Image { get; set; }
    }
}

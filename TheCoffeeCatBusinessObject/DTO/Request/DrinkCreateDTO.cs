using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class DrinkCreateDTO
    { 
        [Required(ErrorMessage = "Name is required.")]
        public string DrinkName { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile Image { get; set; }

    }
}

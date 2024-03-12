using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CatCreateDTO
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The length of name is from 3 to 20 characters!")] 



        [Required(ErrorMessage = "Name is required.")]      
        public string CatName { get; set; }
        [Required(ErrorMessage = "Age is required.")]      
        [Range(2, 10, ErrorMessage = "The Age must from 2 - 10")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Coffee Shop is required.")]
        public Guid CoffeeID { get; set; }
    }
}

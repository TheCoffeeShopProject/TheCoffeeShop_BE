using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class SubscriptionCreateDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Discount percent is required.")]

        public float DiscountPercent { get; set; }
        [Required(ErrorMessage = "price is required.")]

        public double Price { get; set; }
    }
}

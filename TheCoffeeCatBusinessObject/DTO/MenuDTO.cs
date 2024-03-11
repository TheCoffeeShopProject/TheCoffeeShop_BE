using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class MenuDTO
    {
        public Guid MenuID { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Coffee Shop is required.")]
        public Guid CoffeeID { get; set; }

        [Required(ErrorMessage = "Drink is required.")]
        public Guid? DrinkID { get; set; }

        [Required(ErrorMessage = "Cat Product is required.")]
        public Guid? CatProductID { get; set; }

    }
}

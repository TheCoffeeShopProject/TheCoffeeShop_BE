using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.ViewModels
{
    public class MenuVM
    {
        public Guid MenuID { get; set; }
        public bool Status { get; set; }
        public string CoffeeName { get; set; }
        public string? DrinkName { get; set; }
        public double PriceDrink { get; set; }
        public string ImageDrink { get; set; }
        public string? CatProductName { get; set; }
        public double PriceCatProduct { get; set; }
        public string ImageCatProduct { get; set; }
    }
}

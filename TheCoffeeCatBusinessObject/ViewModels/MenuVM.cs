using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.ViewModels
{
    public class MenuVM
    {
        public bool Status { get; set; }
        public Guid CoffeeID { get; set; }
        public Guid? DrinkID { get; set; }
        public Guid? CatProductID { get; set; }
    }
}

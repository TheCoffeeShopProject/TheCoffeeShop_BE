using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject
{
    public class Menu
    {
    
        public Guid MenuID { get; set; }

        public bool Status { get; set; }

        public Guid CoffeeID { get; set; }
        public CoffeeShop CoffeeShop { get; set; }

        public Guid? DrinkID { get; set; }
        public Drink? Drink { get; set; }
        public Guid? CatProductID { get; set; }

        public CatProduct? CatProduct { get; set;}
        public List<OrderDetail>? OrderDetails { get; set; }



    }
}

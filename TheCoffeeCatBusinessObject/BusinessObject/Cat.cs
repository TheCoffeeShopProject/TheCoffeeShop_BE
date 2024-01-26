using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public class Cat
    {
        public Guid CatID { get; set; }
        public string CatName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public Guid CoffeeID { get; set; }
        public CoffeeShop CoffeeShop { get; set; }
    


    }
}

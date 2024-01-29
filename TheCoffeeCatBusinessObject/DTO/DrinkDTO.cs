using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class DrinkDTO
    {
        public string DrinkName { get; set; }
        public double UnitPrice { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

    }
}

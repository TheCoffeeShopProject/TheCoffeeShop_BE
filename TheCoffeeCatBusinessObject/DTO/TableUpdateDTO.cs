using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.DTO
{
    public class TableUpdateDTO
    {
        public Guid TableID { get; set; }
        public string Status { get; set; }
        public Guid CoffeeID { get; set; }
    }
}

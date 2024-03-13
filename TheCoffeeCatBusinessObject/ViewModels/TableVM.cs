using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.ViewModels
{
    public class TableVM
    {
        public Guid TableID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CoffeeName { get; set; }
    }
}

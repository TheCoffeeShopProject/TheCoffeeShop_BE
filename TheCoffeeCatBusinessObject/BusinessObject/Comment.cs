using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoffeeCatBusinessObject.BusinessObject
{
    public  class Comment
    {
        public Guid CommentID { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public bool Status { get; set; }


        public Guid CoffeeID { get; set; }
        public CoffeeShop CoffeeShop { get; set; }

        public Guid CustomerID { get; set; }
       public Customer Customer {  get; set; }
    }
}

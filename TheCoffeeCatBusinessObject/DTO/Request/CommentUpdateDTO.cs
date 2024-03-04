using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatBusinessObject.DTO.Request
{
    public class CommentUpdateDTO
    {
        public string? CommentText { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}

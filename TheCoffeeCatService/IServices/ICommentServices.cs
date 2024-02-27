using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatService.IServices
{
   public interface ICommentServices
    {

        bool ChangeStatus(Comment comment);


        List<Comment> GetComments();
        void AddNew(Comment comment);


        Comment GetCommentById(Guid id);

        void UpdateCommentShop(Comment comment);
    }
}

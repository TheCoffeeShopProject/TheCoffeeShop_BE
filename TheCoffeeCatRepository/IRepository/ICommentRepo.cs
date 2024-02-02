using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatRepository.IRepository
{
    public interface ICommentRepo
    {

        public bool ChangeStatus(Comment comment);


        public List<Comment> GetComments();
        public void AddNew(Comment comment);


        public Comment GetCommentById(Guid id);

        public void UpdateCommentShop(Comment comment);

      
    }
}

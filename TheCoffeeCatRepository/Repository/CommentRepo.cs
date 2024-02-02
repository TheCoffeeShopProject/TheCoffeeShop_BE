using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class CommentRepo : ICommentRepo
    {
        public void AddNew(Comment comment)
        {
            throw new NotImplementedException();
        }

        public bool ChangeStatus(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommentShop(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}

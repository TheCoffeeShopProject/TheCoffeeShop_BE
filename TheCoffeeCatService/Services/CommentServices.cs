using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class CommentServices : ICommentServices
    {

        private ICommentRepo _comment;
        public CommentServices(ICommentRepo comment)
        {
            _comment = comment;
            
        }

        public void AddNew(Comment comment)
        {
            _comment.AddNew(comment);
        }

        public bool ChangeStatus(Comment comment)
        {
           return _comment.ChangeStatus(comment);
        }

        public Comment GetCommentById(Guid id)
        {
            return _comment.GetCommentById(id);
        }

        public List<Comment> GetComments()
        {
            return _comment.GetComments();
        }

        public void UpdateCommentShop(Comment comment)
        {
           _comment.UpdateCommentShop(comment);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class CommentRepo : ICommentRepo
    {
        private CommentDAO dao;
        public CommentRepo()
        {
            dao = new CommentDAO();
        }
        public void AddNew(Comment comment)
        {
            dao.AddComment(comment);
        }

        public bool ChangeStatus(Comment comment)
        {
            return dao.ChangeStatus(comment);
        }

        public Comment GetCommentById(Guid id)
        {
            return dao.GetCommentByID(id);
        }

        public List<Comment> GetComments()
        {
            return dao.GetAllComment();
        }

        public void UpdateCommentShop(Comment comment)
        {
            dao.UpdateComment(comment);
        }
    }
}

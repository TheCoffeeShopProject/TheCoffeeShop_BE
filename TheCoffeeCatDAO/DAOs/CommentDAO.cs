using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class CommentDAO
    {
        private static CommentDAO instance;
        public static CommentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentDAO();
                }
                return instance;
            }


        }

        public List<Comment> GetAllComment()
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Comments.ToList();    
        }

        public bool AddComment (Comment comment)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Comments.SingleOrDefault(c => c.CommentID == comment.CommentID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return true;

            }
        }


        public bool UpdateComment(Comment comment)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Comments.SingleOrDefault(c => c.CommentID == comment.CommentID);

            if (a == null)
            {
                return false;
            }
            else
            {
                _context.Entry(a).CurrentValues.SetValues(comment);
                _context.SaveChanges();
                return true;
            }
        }


        public bool ChangeStatus(Comment comment)
        {
            var _context = new TheCoffeeStoreDBContext();
            var a = _context.Comments.FirstOrDefault(c => c.CommentID.Equals(comment.CommentID));


            if (a == null)
            {
                return false;
            }
            else
            {
                a.Status = false;
                _context.Entry(a).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

        public Comment GetCommentByID(Guid id)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Comments.SingleOrDefault(a => a.CommentID == id);
        }

        public Comment GetCommentByCoffeeID(Comment comment)
        {
            var _context = new TheCoffeeStoreDBContext();
            return _context.Comments.SingleOrDefault(a => a.CoffeeID == comment.CoffeeID);
        }
    }
}

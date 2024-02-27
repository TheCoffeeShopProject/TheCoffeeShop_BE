using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.CommentsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentServices _comment;

        public CommentsController(ICommentServices comment)
        {
            _comment = comment;
        }

        // GET: api/Comments
        [HttpGet]
        public  ActionResult<IEnumerable<Comment>> GetComments()
        {
          if (_comment.GetComments() == null)
          {
              return NotFound();
          }
            //config map 
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new CommentProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();

            // tranfer from cat to catdto

            var data = _comment.GetComments().ToList().Select(comment => mapper.Map<Comment, CommentResponseDTO>(comment));

            return Ok(data);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(Guid id)
        {
          if (_comment.GetComments()== null)
          {
              return NotFound();
          }
            var comment =  _comment.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutComment(Guid id, [FromForm] CommentUpdateDTO commentUpdateDTO)
        {


            try
            {
                var comment = _comment.GetCommentById(id);
                if (commentUpdateDTO.CommentText != null)
                {
                    comment.CommentText = commentUpdateDTO.CommentText;

                }
                if (commentUpdateDTO.UpdateTime != null)
                {
                    comment.UpdateTime = commentUpdateDTO.UpdateTime;

                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_comment.GetComments()==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Comment> PostComment(CommentCreateDTO commentCreateDTO)
        {
            var config = new MapperConfiguration(
                 cfg => cfg.AddProfile(new CommentProfile())
             );
            // create mapper
            var mapper = config.CreateMapper();


            var comment = mapper.Map<Comment>(commentCreateDTO);
            _comment.AddNew(comment);


            return Ok(comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            if (_comment.GetComments() == null)
            {
                return NotFound();
            }
            var comment =  _comment.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _comment.ChangeStatus(comment);

            return NoContent();
        }

      
    }
}

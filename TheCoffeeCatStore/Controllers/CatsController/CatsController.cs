using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatServices _cat;
        public CatsController(ICatServices cat)
        {
            _cat = cat;
        }

        // GET: api/Cats
        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetCats()
        {
          if (_cat.GetCats() == null)
          {
              return NotFound();
          }

          //config map 
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile( new CatProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();

            // tranfer from cat to catdto

            var data = _cat.GetCats().ToList().Select(cat => mapper.Map<Cat, CatDTO>(cat));

            return Ok(data);
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public ActionResult<Cat> GetCat(Guid id)
        {
          if (_cat.GetCats() == null)
          {
              return NotFound();
          }
            var cat =  _cat.GetCatById(id);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok( cat);
        }

        // GET: api/Cats/5
        [HttpGet("search")]
        public ActionResult<Cat> GetCat(string searchValue)
        {
            if (_cat.GetCats() == null)
            {
                return NotFound();
            }
            var cat = _cat.SearchCat(searchValue);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }
        //// PUT: api/Cats/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCat(Guid id, Cat cat)
        //{
        //    if (id != cat.CatID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cat).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CatExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Cat> PostCat(Cat cat)
        {
          if (_cat.GetCats() == null)
          {
              return Problem("Entity set 'TheCoffeeStoreDBContext.Cats'  is null.");
          }
            _cat.AddNew(cat);
       

            return Ok( CreatedAtAction("GetCat", new { id = cat.CatID }, cat));
        }

        //// DELETE: api/Cats/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCat(Guid id)
        //{
        //    if (_context.Cats == null)
        //    {
        //        return NotFound();
        //    }
        //    var cat = await _context.Cats.FindAsync(id);
        //    if (cat == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cats.Remove(cat);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CatExists(Guid id)
        //{
        //    return (_context.Cats?.Any(e => e.CatID == id)).GetValueOrDefault();
        //}
    }
}

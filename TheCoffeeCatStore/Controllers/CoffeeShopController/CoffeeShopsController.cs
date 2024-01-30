using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatStore.Controllers.CoffeeShopController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopsController : ControllerBase
    {
        private readonly TheCoffeeStoreDBContext _context;

        public CoffeeShopsController(TheCoffeeStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeShop>>> GetCofffeeShops()
        {
          if (_context.CofffeeShops == null)
          {
              return NotFound();
          }
            return await _context.CofffeeShops.ToListAsync();
        }

        // GET: api/CoffeeShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeShop>> GetCoffeeShop(Guid id)
        {
          if (_context.CofffeeShops == null)
          {
              return NotFound();
          }
            var coffeeShop = await _context.CofffeeShops.FindAsync(id);

            if (coffeeShop == null)
            {
                return NotFound();
            }

            return coffeeShop;
        }

        // PUT: api/CoffeeShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffeeShop(Guid id, CoffeeShop coffeeShop)
        {
            if (id != coffeeShop.CoffeeID)
            {
                return BadRequest();
            }

            _context.Entry(coffeeShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeShopExists(id))
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

        // POST: api/CoffeeShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoffeeShop>> PostCoffeeShop(CoffeeShop coffeeShop)
        {
          if (_context.CofffeeShops == null)
          {
              return Problem("Entity set 'TheCoffeeStoreDBContext.CofffeeShops'  is null.");
          }
            _context.CofffeeShops.Add(coffeeShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoffeeShop", new { id = coffeeShop.CoffeeID }, coffeeShop);
        }

        // DELETE: api/CoffeeShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeShop(Guid id)
        {
            if (_context.CofffeeShops == null)
            {
                return NotFound();
            }
            var coffeeShop = await _context.CofffeeShops.FindAsync(id);
            if (coffeeShop == null)
            {
                return NotFound();
            }

            _context.CofffeeShops.Remove(coffeeShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeShopExists(Guid id)
        {
            return (_context.CofffeeShops?.Any(e => e.CoffeeID == id)).GetValueOrDefault();
        }
    }
}

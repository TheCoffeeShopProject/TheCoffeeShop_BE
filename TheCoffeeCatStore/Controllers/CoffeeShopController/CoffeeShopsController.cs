using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.CoffeeShopController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopsController : ControllerBase
    {
        private readonly ICoffeeShopServices _coffee;

        public CoffeeShopsController(ICoffeeShopServices coffee)
        {
            _coffee = coffee;
        }

        // GET: api/CoffeeShops
        [HttpGet]
        public ActionResult<IEnumerable<CoffeeShop>> GetCofffeeShops()
        {
          if (_coffee.GetCoffees() == null)
          {
              return NotFound();
          }
            return _coffee.GetCoffees().ToList();
        }

        // GET: api/CoffeeShops/5
        [HttpGet("{id}")]
        public ActionResult<CoffeeShop> GetCoffeeShop(Guid id)
        {
          if (_coffee.GetCoffees() == null)
          {
              return NotFound();
          }
            var coffeeShop =  _coffee.GetCoffeeShopById(id);

            if (coffeeShop == null)
            {
                return NotFound();
            }

            return Ok( coffeeShop);
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

         

       

            try
            {
                _coffee.UpdateCoffee(coffeeShop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_coffee.GetCoffeeShopById(id)==null)
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
        public ActionResult<CoffeeShop> PostCoffeeShop(CoffeeShop coffeeShop)
        {
          if (_coffee.GetCoffees() == null)
          {
              return Problem("Entity set 'TheCoffeeStoreDBContext.CofffeeShops'  is null.");
          }
            _coffee.AddNew(coffeeShop);

            return CreatedAtAction("GetCoffeeShop", new { id = coffeeShop.CoffeeID }, coffeeShop);
        }

        // DELETE: api/CoffeeShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeShop(Guid id)
        {
            if (_coffee.GetCoffees()== null)
            {
                return NotFound();
            }
            var coffeeShop = _coffee.GetCoffeeShopById(id);
            if (coffeeShop == null)
            {
                return NotFound();
            }
            _coffee.ChangeStatus(coffeeShop);

            return NoContent();
        }

    }
}

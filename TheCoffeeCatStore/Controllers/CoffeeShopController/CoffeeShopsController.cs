using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Request;
using TheCoffeeCatBusinessObject.DTO.Response;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.CoffeeShopController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopsController : ControllerBase
    {
        private readonly ICoffeeShopServices _coffee;
        private readonly BlobServiceClient _blobServiceClient;

        public CoffeeShopsController(ICoffeeShopServices coffee, BlobServiceClient blobServiceClient)
        {
            _coffee = coffee;
            _blobServiceClient = blobServiceClient;
        }

        // GET: api/CoffeeShops
        [HttpGet]
        public ActionResult<IEnumerable<CoffeeShop>> GetCoffeeShops()
        {
          if (_coffee.GetCoffees() == null)
          {
              return NotFound();
          }
            //config map 
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new CoffeeShopProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();

            // tranfer from cat to catdto

            var data = _coffee.GetCoffees().ToList().Select(coffeeshop => mapper.Map<CoffeeShop, CoffeeResponseDTO>(coffeeshop));

            return Ok(data);
        }

        // GET: api/CoffeeShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeShop>> GetCoffeeShop(Guid id)
        {
            if (_coffee.GetCoffees() == null)
            {
                return NotFound();
            }
            var coffeeShop = _coffee.GetCoffeeShopById(id);

            if (coffeeShop == null)
            {
                return NotFound();
            }

            return Ok(coffeeShop);
        }

        //// PUT: api/CoffeeShops/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCoffeeShop(Guid id, CoffeeShop coffeeShop)
        //{
        //    if (id != coffeeShop.CoffeeID)
        //    {
        //        return BadRequest();
        //    }





        //    try
        //    {
        //        _coffee.UpdateCoffee(coffeeShop);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (_coffee.GetCoffeeShopById(id)==null)
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

        // POST: api/CoffeeShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CoffeeShop> AddNewCoffeeShop(CoffeeCreateDTO coffeecreateDTO)
        {
            var config = new MapperConfiguration(
               cfg => cfg.AddProfile(new CoffeeShopProfile())
           );
            // create mapper
            var mapper = config.CreateMapper();


            var coffee = mapper.Map<CoffeeShop>(coffeecreateDTO);
            _coffee.AddNew(coffee);


            return Ok(coffee);
        }

        // DELETE: api/CoffeeShops/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCoffeeShop(Guid id)
        {
            if (_coffee.GetCoffees() == null)
            {
                return NotFound();
            }
            var coffeeShop = _coffee.GetCoffeeShopById(id);
            if (coffeeShop == null)
            {
                return NotFound();
            }

            _coffee.ChangeStatus(coffeeShop);

            return Ok("Delete Successfully");
        }


    }
}

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
        [HttpPut("{id}")]
        public IActionResult UpdateCoffeeShop(Guid id, [FromForm] CoffeeUpdateDTO coffeeUpdateDTO )
        {

            try
            {
                var coffeeshop = _coffee.GetCoffeeShopById(id);
              

                var containerInstance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
                //get file name from request and upload to azure blod storage
                var blobName = $"{(Guid.NewGuid())} {coffeeUpdateDTO.Image?.FileName}";
                //local file path
                var blobInstance = containerInstance.GetBlobClient(blobName);
                //upload file to azure blob storge
                blobInstance.Upload(coffeeUpdateDTO.Image?.OpenReadStream());
                //storageAccountUrl
                var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
                //get blod url
                var blobUrl = $"{storageAccountUrl}/{blobName}";


                if (coffeeUpdateDTO.OpenTime != null)
                {
                    coffeeshop.OpenTime = coffeeUpdateDTO.OpenTime;
                    
                }
                if (coffeeUpdateDTO.CloseTime != null)
                {
                    coffeeshop.CloseTime = coffeeUpdateDTO.CloseTime;
                }
                if (coffeeUpdateDTO.PhoneNumber != null)
                {
                    coffeeshop.PhoneNumber = coffeeUpdateDTO.PhoneNumber;
                   
                }
                if (coffeeUpdateDTO.Description != null)
                {
                    coffeeshop.Description = coffeeUpdateDTO.Description;
                }
                if (coffeeUpdateDTO.Status != null)
                {
                    coffeeshop.Status = (bool)coffeeUpdateDTO.Status;
                }
                if (coffeeUpdateDTO.Image != null)
                {
                    coffeeshop.Image = blobUrl;
                }

                _coffee.UpdateCoffee(coffeeshop);

            
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_coffee.GetCoffeeShopById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update Successfully");
        }

        //  POST: api/CoffeeShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CoffeeShop> AddNewCat([FromForm] CoffeeCreateDTO coffeecreateDTO)
        {

            var containerInstance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
            //get file name from request and upload to azure blod storage
            var blobName = $"{(Guid.NewGuid())} {coffeecreateDTO.Image?.FileName}";
            //local file path
            var blobInstance = containerInstance.GetBlobClient(blobName);


            //storageAccountUrl
            var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
            //get blod url
            var blobUrl = $"{storageAccountUrl}/{blobName}";
            var config = new MapperConfiguration(
              cfg => cfg.AddProfile(new CoffeeShopProfile())
          );
            // create mapper
            var mapper = config.CreateMapper();


            var coffee = mapper.Map<CoffeeShop>(coffeecreateDTO);
            coffee.Image = blobUrl;
            _coffee.AddNew(coffee);


            return Ok("Create Successfully");
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

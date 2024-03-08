using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.DTO.Request;

using TheCoffeeCatBusinessObject.DTO.Response;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatServices _cat;
        private readonly BlobServiceClient _blobServiceClient ;
        public CatsController(ICatServices cat, BlobServiceClient blobServiceClient)
        {
            _cat = cat;
            _blobServiceClient = blobServiceClient;
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
                cfg => cfg.AddProfile(new CatProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();

            // tranfer from cat to catdto

            var data = _cat.GetCats().ToList().Select(cat => mapper.Map<Cat, CatResponseDTO>(cat));

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
            var cat = _cat.GetCatById(id);

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
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
                return NotFound("Don't have this cat ");
            }

            return Ok(cat);
        }
        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateCat(Guid id,[FromForm] CatUpdateDTO catUpdateDTO)
        {

            try
            {

                var cat = _cat.GetCatById(id);
                
                var containerInstance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
                //get file name from request and upload to azure blod storage
                var blobName =  $"{(Guid.NewGuid())} {catUpdateDTO.Image?.FileName}";
                //local file path
                var blobInstance = containerInstance.GetBlobClient (blobName);
                //upload file to azure blob storge
                if(catUpdateDTO.Image != null)
                {
                    blobInstance.Upload(catUpdateDTO.Image?.OpenReadStream());
                }
                
                //storageAccountUrl
                var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
                //get blod url
                var blobUrl = $"{storageAccountUrl}/{blobName}";
                if (catUpdateDTO.CatName != null)
                {
                    cat.CatName = catUpdateDTO.CatName;
                }

                if (catUpdateDTO.Age != null)
                {
                    cat.Age = (int)catUpdateDTO.Age;
                }
                if (catUpdateDTO.Description != null)
                {
                    cat.Description = catUpdateDTO.Description;
                }
                if (catUpdateDTO.Image != null)
                {
                    cat.Image = blobUrl;
                }
                if (catUpdateDTO.CoffeeID != null)
                {
                    cat.CoffeeID = (Guid)catUpdateDTO.CoffeeID;
                }
                if (catUpdateDTO.Status != null)
                {
                    cat.Status = (bool)catUpdateDTO.Status;
                }


                _cat.UpdateCat(cat);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_cat.GetCatById(id) == null)
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

        //  POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Cat> AddNewCat([FromForm] CatCreateDTO catcreateDTO)
        {

            var containerInstance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
            //get file name from request and upload to azure blod storage
            var blobName = $"{(Guid.NewGuid())} {catcreateDTO.Image?.FileName}";
            //local file path
            var blobInstance = containerInstance.GetBlobClient(blobName);
          

            //storageAccountUrl
            var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
            //get blod url
            var blobUrl = $"{storageAccountUrl}/{blobName}";
            var config = new MapperConfiguration(
              cfg => cfg.AddProfile(new CatProfile())
          );
            // create mapper
            var mapper = config.CreateMapper();


            var cat = mapper.Map<Cat>(catcreateDTO);
            cat.Image = blobUrl;
            _cat.AddNew(cat);


            return Ok("Create Successfully");
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCat(Guid id)
        {
            if (_cat.GetCats() == null)
            {
                return NotFound();
            }
            var cat = _cat.GetCatById(id);
            if (cat == null)
            {
                return NotFound();
            }

            _cat.ChangeStatus(cat);


            return Ok("Delete Successfully");
        }
    }
}

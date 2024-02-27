using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;
using TheCoffeeCatStore.Mapper;

namespace TheCoffeeCatStore.Controllers.CatProdctsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatProductsController : ControllerBase
    {
        private readonly ICatProductServices _services;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;
        public CatProductsController(ICatProductServices services, IMapper mapper, BlobServiceClient blobServiceClient)
        {
            _services = services;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }
        [HttpGet]
        public IActionResult GetCatProdcts()
        {
            try
            {
                var catProdct = _services.GetCatProducts();
                var response = _mapper.Map<List<CatProductDTO>>(catProdct);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<CatProduct> GetCatProductById([FromRoute] Guid id)
        {
            try
            {
                var catProduct = _services.GetCatProductById(id);
                var response = _mapper.Map<CatProductDTO>(catProduct);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("search")]
        public ActionResult GetCatProductByName(string name)
        {
            try
            {
                var _cat = _services.SearchCatProduct(name);
                var resposne = _mapper.Map<List<CatProductDTO>>(_cat);
                return Ok(resposne);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public ActionResult AddCatProduct([FromForm] CatProductDTO catProduct)
        {

            try
            {
                var containerIntance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
                var blobName = $"{Guid.NewGuid()}{catProduct.Image?.FileName}";
                var blobInstance = containerIntance.GetBlobClient(blobName);

                blobInstance.Upload(catProduct.Image?.OpenReadStream());

                var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
                var blobUrl = $"{storageAccountUrl}/{blobName}";
                var _cat = _mapper.Map<CatProduct>(catProduct);
                _cat.Image = blobUrl;
                _services.AddCatProdct(_cat);
                return Ok(_cat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateCatProduct([FromRoute] Guid id, [FromForm] CatProductDTO catProductDTO)
        {

            try
            {
                // upload
                var containerInstance = _blobServiceClient.GetBlobContainerClient("thecoffeeshoppictures");
                var blodName = $"{Guid.NewGuid()} {catProductDTO.Image?.FileName}";
                var blodInstance = containerInstance.GetBlobClient(blodName);
                blodInstance.Upload(catProductDTO.Image.OpenReadStream());
                var storageAccountUrl = "https://thecoffeeshopimage.blob.core.windows.net/thecoffeeshoppictures";
                var blodUrl = $"{storageAccountUrl}/{blodName}";
                //------------
                var _cat = _services.GetCatProductById(id);
                if (catProductDTO.CatProductName != null)
                {
                    _cat.CatProductName = catProductDTO.CatProductName;
                }
                if (catProductDTO.CatProductType != null)
                {
                    _cat.CatProductType = catProductDTO.CatProductType;
                }
                if (catProductDTO.Status != _cat.Status)
                {
                    _cat.Status = catProductDTO.Status;
                }
                if (catProductDTO.Image != null)
                {
                    _cat.Image = blodUrl;
                }
                if (catProductDTO.Price != _cat.Price)
                {
                    _cat.Price = catProductDTO.Price;
                }
                _services.UpdateCatProdct(_cat);


            }
            catch (DbUpdateConcurrencyException)
            {
                if (_services.GetCatProductById(id) == null)
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
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCatProduct([FromRoute] Guid id)
        {
            var res = _services.GetCatProducts();
            if (res == null)
            {
                return NotFound();
            }
            var res2 = _services.GetCatProductById(id);
            if (res2 == null)
            {
                return NotFound();
            }
            _services.ChangeStatus(res2);
            return Ok("Delete Success");


        }

    }
}

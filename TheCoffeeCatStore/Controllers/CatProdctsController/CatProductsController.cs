using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
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
        public CatProductsController(ICatProductServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
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
        public ActionResult<CatProduct> GetCatProductById([FromRoute] Guid id) {
            try
            {
                var catProduct = _services.GetCatProductById(id);
                var response = _mapper.Map<CatProductDTO>(catProduct);
                return Ok(response);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("search")]
        public ActionResult GetCatProductByName(string name) {
            try
            {
                var _cat = _services.SearchCatProduct(name);
                var resposne = _mapper.Map<List<CatProductDTO>>(_cat);
                return Ok(resposne);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public ActionResult AddCatProduct(CatProductDTO catProduct)
        {
            try
            {
                var _cat = _mapper.Map<CatProduct>(catProduct);
                _services.AddCatProdct(_cat);
                return Ok(_cat);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public ActionResult UpdateCatProduct([FromRoute]Guid id,[FromForm] CatProductDTO catProductDTO) 
        {
            try { 
            var _cat = _services.GetCatProductById(id);
            if(catProductDTO.CatProductName != null)
            {
                _cat.CatProductName = catProductDTO.CatProductName;
            }
            if (catProductDTO.CatProductType != null)
            {
                _cat.CatProductType = catProductDTO.CatProductType;
            }
            if (catProductDTO.Status != null)
            {
                _cat.Status = catProductDTO.Status;
            }
            if (catProductDTO.Image != null)
            {
                _cat.Image = catProductDTO.Image;
            }
            if (catProductDTO.Price != null)
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

    }
}

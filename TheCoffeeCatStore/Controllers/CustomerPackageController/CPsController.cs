using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatService.IServices;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO.Response;
using TheCoffeeCatBusinessObject.DTO.Request;

namespace TheCoffeeCatStore.Controllers.CustomerPackageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerPackageServices _cp;
        public CPsController(IMapper mapper,ICustomerPackageServices cp)
        {
            _mapper = mapper;
            _cp = cp;
        }
        [HttpGet]
        public ActionResult<CustomerPackage> GetCustomersPackages()
        {
            try
            {
                var cp = _cp.GetCPs();
                if (cp == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<List<CustomerPackageResponseDTO>>(cp);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<Subscription> GetCustomerPackageById(Guid id)
        {

            try
            {
                var cp = _cp.GetCPById(id);
                var response = _mapper.Map<CustomerPackageResponseDTO>(cp);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public ActionResult<Subscription> GetCustomerPackageByName(string searchvalue)
        {

            try
            {
                var cp = _cp.SearchCP(searchvalue);
                var response = _mapper.Map<List<CustomerPackageResponseDTO>>(cp);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult AddCustomerPackage([FromForm] CustomerPackageCreateDTO customerPackageDTO)
        {
            try
            {
                var response = _mapper.Map<CustomerPackage>(customerPackageDTO);
                _cp.AddNew(response);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCustomerPackage([FromRoute] Guid id, [FromForm] CustomerPackageUpdateDTO customerPackageDTO)
        {

            try
            {

                var cp = _cp.GetCPById(id);
                if (customerPackageDTO.DateStart != null)
                {
                    cp.DateStart = (DateTime)customerPackageDTO.DateStart;
                }
                if (customerPackageDTO.DateEnd != null)
                {
                    cp.DateEnd = (DateTime)customerPackageDTO.DateEnd;
                }
                if (customerPackageDTO.CustomerID != null)
                {
                  cp.CustomerID = (Guid)customerPackageDTO.CustomerID;
                }

                if (customerPackageDTO.SubscriptionID != null)
                {
                    cp.SubscriptionID = (Guid)customerPackageDTO.SubscriptionID;
                }

                _cp.UpdateCP(cp);


            }
            catch (DbUpdateConcurrencyException)
            {
                if (_cp.GetCPById(id) == null)
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

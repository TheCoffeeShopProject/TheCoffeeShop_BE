using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatService.IServices;
using TheCoffeeCatBusinessObject.BusinessObject;

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
                var response = _mapper.Map<List<CustomerPackageDTO>>(cp);
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
                var response = _mapper.Map<CustomerPackageDTO>(cp);
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
                var response = _mapper.Map<List<CustomerPackageDTO>>(cp);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult AddCustomerPackage([FromForm] CustomerPackageDTO customerPackageDTO)
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
        public ActionResult UpdateCustomerPackage([FromRoute] Guid id, [FromForm] CustomerPackageDTO customerPackageDTO)
        {

            try
            {

                var cp = _cp.GetCPById(id);
                if (customerPackageDTO.DateStart != null)
                {
                    cp.DateStart = customerPackageDTO.DateStart;
                }
                if (customerPackageDTO.DateEnd != null)
                {
                    cp.DateEnd = customerPackageDTO.DateEnd;
                }
                if (customerPackageDTO.CustomerID != null)
                {
                  cp.CustomerID = customerPackageDTO.CustomerID;
                }

                if (customerPackageDTO.SubscriptionID != null)
                {
                    cp.SubscriptionID = customerPackageDTO.SubscriptionID;
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

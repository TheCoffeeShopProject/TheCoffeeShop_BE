using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.CustomersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerServices _cus;
        public CustomersController(IMapper mapper, ICustomerServices cus)
        {
            _mapper = mapper;
            _cus = cus;
        }
        [HttpGet]
            public ActionResult GetCustomers()
            {
                try
                {
                    var cus = _cus.GetCustomers();
                    var response = _mapper.Map<List<CustomerDTO>>(cus);
                    return Ok(response);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult GetCustomerById(Guid id)
        {

            try
            {
                var cus = _cus.GetCustomerById(id);
                var response = _mapper.Map<CustomerDTO>(cus);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public ActionResult GetCustomerByName(string searchvalue)
        {

            try
            {
                var cus = _cus.SearchCustomer(searchvalue);
                var response = _mapper.Map<List<CustomerDTO>>(cus);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult AddCustomer([FromForm] CustomerDTO cus)
        {
            try
            {
                var response = _mapper.Map<Customer>(cus);
                _cus.AddNew(response);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCustomer([FromRoute] Guid id, [FromForm] CustomerDTO _cusDTO)
        {

            try
            {

                var customer = _cus.GetCustomerById(id);
                if (_cusDTO.FullName != null)
                {
                    customer.FullName = _cusDTO.FullName;
                }
                if (_cusDTO.PhoneNumber != null)
                {
                    customer.PhoneNumber = _cusDTO.PhoneNumber;
                }
                _cus.UpdateCustomer(customer);


            }
            catch (DbUpdateConcurrencyException)
            {
                if (_cus.GetCustomerById(id) == null)
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

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatStore.Controllers.StaffsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffServices _staffServices;
        private readonly IMapper _mapper;

        public StaffsController(IStaffServices staffServices, IMapper mapper)
        {
            _staffServices = staffServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            try
            {
                if (_staffServices.GetAllStaff() == null)
                {
                    return NotFound();
                }
                var staffs = _staffServices.GetAllStaff();
                var response = _mapper.Map<List<StaffVM>>(staffs);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStaffByID(Guid id)
        {
            var staff = _staffServices.GetStaffByID(id);

            var responese = _mapper.Map<StaffVM>(staff);

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewStaff(StaffVM staff)
        {
            try
            {
                var _staff = _mapper.Map<Staff>(staff);
                _staffServices.AddNewStaff(_staff);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStaff(StaffDTO staff, Guid id)
        {
            try
            {
                if (staff.StaffID != id)
                {
                    return NotFound();
                }
                var _staff = _mapper.Map<Staff>(staff);
                _staffServices.UpdateStaff(_staff);

                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

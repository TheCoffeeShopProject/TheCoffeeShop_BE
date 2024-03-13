using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;

namespace TheCoffeeCatStore.Controllers.StaffsController
{
    //[Authorize(Roles = "Admin ,e9e125c5-defc-4035-a6b7-3f23c83453ba")]
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
        public IActionResult AddNewStaff(StaffCreateDTO staff)
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

        [HttpPut("{id}")]
        public IActionResult UpdateStaff([FromForm] StaffUpdateDTO staff, Guid id)
        {
            try
            {
                var staffs = _staffServices.GetStaffByID(id);
                if (staff.FullName != null)
                {
                    staffs.FullName = staff.FullName;
                }
                if (staff.PhoneNumber != null)
                {
                    staffs.PhoneNumber = staff.PhoneNumber;
                }
                if (staff.Address != null)
                {
                    staffs.Address = staff.Address;
                }
                if (staff.DOB != null)
                {
                    staffs.DOB = staff.DOB;
                }
                if (staff.CoffeeID != null)
                {
                    staffs.CoffeeID = (Guid)staff.CoffeeID;
                }
                if (staff.AccountID != null)
                {
                    staffs.AccountID = (Guid)staff.AccountID;
                }



                _staffServices.UpdateStaff(staffs);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

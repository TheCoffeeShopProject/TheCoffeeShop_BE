using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
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
        private readonly IAccountServices _accountServices;
        private readonly IStaffServices _staffServices;
        private readonly IMapper _mapper;

        public StaffsController(IStaffServices staffServices, IAccountServices accountServices, IMapper mapper)
        {
            _staffServices = staffServices;
            _accountServices = accountServices;
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
        public IActionResult AddNewStaff(RegisterStaffVM accountStaff)
        {
            try
            {
                var checkEmail = _accountServices.GetAllAccount().Where(u =>
                u.Email.Equals(accountStaff.Email)).FirstOrDefault();

                if (checkEmail != null)
                {
                    return BadRequest("Email Existed");
                }

                var account = new AccountCreateDTO
                {
                    AccountID = Guid.NewGuid(),
                    Email = accountStaff.Email,
                    Password = accountStaff.Password,
                    Status = true,
                    RoleID = new Guid("64dd1a12-3f2b-445e-951b-6da41bbb9b30")
                };

                var _account = _mapper.Map<Account>(account);
                _accountServices.AddNewAccount(_account);

                var staff = new StaffCreateDTO
                {
                    StaffID = Guid.NewGuid(),
                    FullName = accountStaff.FullName,
                    PhoneNumber = accountStaff.PhoneNumber,
                    Address = accountStaff.Address,
                    DOB = accountStaff.DOB,
                    CoffeeID = accountStaff.CoffeeID,
                    AccountID = account.AccountID
                };

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
        public IActionResult UpdateStaff(StaffUpdateDTO staff, Guid id)
        {
            try
            {
                if (staff.StaffID != id)
                {
                    return NotFound();
                }
                var _staff = _mapper.Map<Staff>(staff);
                _staffServices.UpdateStaff(_staff);

                return Ok("Update Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

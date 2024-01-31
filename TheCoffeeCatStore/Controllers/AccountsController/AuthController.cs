using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;
using TheCoffeeCatStore.Admin;

namespace TheCoffeeCatStore.Controllers.AccountsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AuthController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM accountLogin)
        {
            try
            {
                if (accountLogin.Email == AdminConfig.GetAdminEmail() && accountLogin.Password == AdminConfig.GetAdminPassword())
                {
                    return Ok("Admin");
                }

                var checkLogin = _accountServices.CheckLogin(accountLogin.Email, accountLogin.Password);
                if (checkLogin != null)
                {
                    if (checkLogin.Status != true)
                    {
                        return BadRequest("You are not allowed access into system");
                    }
                    if (checkLogin.RoleID.Equals(new Guid("94dab4fc-2c2a-4813-9691-d3bb42bb3760"))) //Customer
                    {
                        return Ok("Customer");
                    }
                    if (checkLogin.RoleID.Equals(new Guid("e9e125c5-defc-4035-a6b7-3f23c83453ba"))) //Manager
                    {
                        return Ok("Manager");
                    }
                    if (checkLogin.RoleID.Equals(new Guid("64dd1a12-3f2b-445e-951b-6da41bbb9b30"))) //Staff
                    {
                        return Ok("Staff");
                    }

                    return BadRequest("Incorect User Name or Password Please Try Again");

                }
                
                return Unauthorized();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}

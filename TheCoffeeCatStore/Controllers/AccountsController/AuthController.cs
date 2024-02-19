using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration _config;

        public AuthController(IAccountServices accountServices, IConfiguration config)
        {
            _accountServices = accountServices;
            _config = config;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVM accountLogin)
        {
            try
            {
                if (accountLogin.Email == AdminConfig.GetAdminEmail() && accountLogin.Password == AdminConfig.GetAdminPassword())
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Email, "admin@gmail.com"),
                        new Claim(ClaimTypes.Role, "Admin")

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var _token = new JwtSecurityTokenHandler().WriteToken(token);

                    HttpContext.Response.Cookies.Append("AdminCookie", _token, new CookieOptions
                    {
                        HttpOnly = true, // Chỉ có thể được đọc bằng cách sử dụng HTTP (không sử dụng JavaScript)
                        Secure = true,   // Chỉ sử dụng khi kết nối an toàn (HTTPS)
                        SameSite = SameSiteMode.None, // Hoặc SameSiteMode.Strict, tùy thuộc vào yêu cầu của ứng dụng
                        Expires = DateTime.UtcNow.AddMinutes(10) // Thời gian hết hạn của cookie
                    });

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }

                var checkLogin = _accountServices.CheckLogin(accountLogin.Email, accountLogin.Password);
                if (checkLogin != null)
                {
                    if (checkLogin.Status != true)
                    {
                        return BadRequest("You are not allowed access into system");
                    }
                    //if (checkLogin.RoleID.Equals(new Guid("94dab4fc-2c2a-4813-9691-d3bb42bb3760"))) //Customer
                    //{
                    //    return Ok("Customer");
                    //}
                    //if (checkLogin.RoleID.Equals(new Guid("e9e125c5-defc-4035-a6b7-3f23c83453ba"))) //Manager
                    //{
                    //    return Ok("Manager");
                    //}
                    //if (checkLogin.RoleID.Equals(new Guid("64dd1a12-3f2b-445e-951b-6da41bbb9b30"))) //Staff
                    //{
                    //    return Ok("Staff");
                    //}
                    var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, checkLogin.AccountID.ToString()),
                        new Claim(ClaimTypes.Email, checkLogin.Email),
                        new Claim(ClaimTypes.Role, checkLogin.RoleID.ToString())
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    var _token = new JwtSecurityTokenHandler().WriteToken(token);

                    SetCookie("UserCookie", _token);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }

                return BadRequest("Incorect User Name or Password Please Try Again");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        private void SetCookie(string nameCookie, string value)
        {
            CookieOptions cookieOptions = new();
            cookieOptions.HttpOnly = true;
            cookieOptions.Secure = true;
            cookieOptions.Expires = DateTime.Now.AddMinutes(10);
            HttpContext.Response.Cookies.Append(nameCookie, value);
        }

    }
}

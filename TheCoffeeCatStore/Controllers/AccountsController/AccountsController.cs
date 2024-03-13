using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;

namespace TheCoffeeCatStore.Controllers.AccountController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        private readonly IMapper _mapper;

        public AccountsController(IAccountServices accountServices, IMapper mapper)
        {
            _accountServices = accountServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAccount()
        {
            try
            {
                if (_accountServices.GetAllAccount() == null)
                {
                    return NotFound();
                }
                var accounts = _accountServices.GetAllAccount();
                var response = _mapper.Map<List<AccountVM>>(accounts);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountByID(Guid id)
        {
            var account = _accountServices.GetAccountByID(id);

            var responese = _mapper.Map<AccountVM>(account);

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewAccount(AccountCreateDTO account)
        {
            try
            {
                var _account = _mapper.Map<Account>(account);
                _accountServices.AddNewAccount(_account);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount([FromForm] AccountUpdateDTO account, Guid id)
        {
            try
            {
                var accounts = _accountServices.GetAccountByID(id);
                if (account.Email != null)
                {
                    accounts.Email = account.Email;
                }
                if (account.Password != null)
                {
                    accounts.Password = account.Password;
                }
                if (account.Status != null)
                {
                    accounts.Status = (bool)account.Status;
                }
                if (account.RoleID != null)
                {
                    accounts.RoleID = (Guid)account.RoleID;
                }

                _accountServices.UpdateAccount(accounts);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(Guid id)
        {
            if (_accountServices.GetAllAccount() == null)
            {
                return NotFound();
            }
            var account = _accountServices.GetAccountByID(id);
            if (account == null)
            {
                return NotFound();
            }

            _accountServices.ChangeStatusAccount(account);


            return Ok("Delete Successfully");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var checkEmail = _accountServices.GetAllAccount().Where(u =>
                u.Email.Equals(register.Email)).FirstOrDefault();

            if (checkEmail != null)
            {
                return BadRequest("Email Existed");
            }

            var account = new AccountCreateDTO
            {
                AccountID = Guid.NewGuid(),
                Email = register.Email,
                Password = register.Password,
                Status = true,
                RoleID = new Guid("94dab4fc-2c2a-4813-9691-d3bb42bb3760")
            };

            var _account = _mapper.Map<Account>(account);
            _accountServices.AddNewAccount(_account);

            return Ok(account);

        }


    }
}

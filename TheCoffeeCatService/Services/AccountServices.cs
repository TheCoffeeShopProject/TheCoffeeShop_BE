using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatRepository.IRepository;
using TheCoffeeCatService.IServices;

namespace TheCoffeeCatService.Services
{
    public class AccountServices: IAccountServices
    {
        private readonly IAccountRepo _accountRepo;
        public AccountServices(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public void AddNewAccount(Account account) => _accountRepo.AddNewAccount(account);

        public bool ChangeStatusAccount(Account account) => _accountRepo.ChangeStatusAccount(account);

        public Account CheckLogin(string email, string password) => _accountRepo.CheckLogin(email, password);

        public Account GetAccountByID(Guid id) => _accountRepo.GetAccountByID(id);

        public List<Account> GetAllAccount() => _accountRepo.GetAllAccount();

        public void UpdateAccount(Account account) => _accountRepo.UpdateAccount(account);

    }
}

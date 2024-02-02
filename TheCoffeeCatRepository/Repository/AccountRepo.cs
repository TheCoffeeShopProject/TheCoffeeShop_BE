using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatDAO.DAOs;
using TheCoffeeCatRepository.IRepository;

namespace TheCoffeeCatRepository.Repository
{
    public class AccountRepo : IAccountRepo
    {
        AccountDAO dao = new AccountDAO();
        public void AddNewAccount(Account account) => dao.AddNewAccount(account);

        public bool ChangeStatusAccount(Account account) => dao.ChangeStatusAccount(account);

        public Account CheckLogin(string email, string password) => dao.CheckLogin(email, password);

        public Account GetAccountByID(Guid id) => dao.GetAccountByID(id);

        public List<Account> GetAllAccount() => dao.GetAllAccount();

        public void UpdateAccount(Account account) => dao.UpdateAccount(account);

    }
}

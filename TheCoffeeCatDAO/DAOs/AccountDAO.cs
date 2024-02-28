using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;

namespace TheCoffeeCatDAO.DAOs
{
    public class AccountDAO
    {
        private readonly TheCoffeeStoreDBContext _context;
        public AccountDAO()
        {
            _context = new TheCoffeeStoreDBContext();
        }

        public Account CheckLogin(string email, string password)
        {
            //try
            //{
            //    var check = _context.Accounts.Where(u => u.Email!.Equals(email) && u.Password!.Equals(password)).FirstOrDefault();

            //    if (check != null)
            //    {
            //        return check;
            //    }
            //    throw new Exception();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            return _context.Accounts.Where(u => u.Email!.Equals(email) && u.Password!.Equals(password)).FirstOrDefault();
        }

        public List<Account> GetAllAccount()
        {
            try
            {
                return _context.Accounts.Include(a => a.Role).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewAccount(Account account)
        {
            try
            {
                _context.Add(account);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Account GetAccountByID(Guid id)
        {
            try
            {
                var account = _context.Accounts.Include(a => a.Role)
                                               .SingleOrDefault(c => c.AccountID == id);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccount(Account account)
        {
            try
            {
                _context.Attach(account).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatusAccount(Account account)
        {
            var _account = _context.Accounts.FirstOrDefault(c => c.AccountID.Equals(account.AccountID));


            if (_account == null)
            {
                return false;
            }
            else
            {
                _account.Status = false;
                _context.Entry(_account).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }


    }
}

using DAL.Data;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;

        public AccountRepository() 
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public Account GetAccountByEmail(string email)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email);
        }

        public Employee GetEmployeeById(string accountId)
        {
            try
            {
                return _context.Employees.FirstOrDefault(e => e.AccountId == accountId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Customer GetCustomerById(string accountId)
        {
            try
            {
                return _context.Customers.FirstOrDefault(c => c.AccountId == accountId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddAccount(Account account) 
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public bool checkDuplicatePhone(string phone) 
        {
            var account = _context.Accounts.FirstOrDefault(a => a.PhoneNumber == phone);
            if (account != null)
            {
                return true;
            }
            return false;
        }
    }
}

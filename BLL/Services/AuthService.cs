using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        public AuthService() 
        {
            _accountRepository = new AccountRepository();
        }
        public Account Authenticate(string email, string password)
        {
            Account account = _accountRepository.GetAccountByEmail(email);
  
            if(account == null)
            {
                throw new Exception("Email not existed");
            }

            if (account.Password != password)
            {
                throw new Exception("Incorrect password.");
            }

            return account;
        }

        public Customer GetCustomerById(string accountId)
        {
            return _accountRepository.GetCustomerById(accountId);
        }

        public Employee GetEmployeeById(string accountId)
        {
            return _accountRepository.GetEmployeeById(accountId);
        }
    }
}

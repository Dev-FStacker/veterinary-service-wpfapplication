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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService() 
        {
            accountRepository = new AccountRepository();
        }
        public Account GetAccountByEmail(string email) => accountRepository.GetAccountByEmail(email);

        public void AddAccount(Account account) => accountRepository.AddAccount(account);
    }
}

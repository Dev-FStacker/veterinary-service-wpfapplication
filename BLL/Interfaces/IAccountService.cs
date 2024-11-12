using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        public Account GetAccountByEmail(string email);
        public void AddAccount(Account account);
    }
}

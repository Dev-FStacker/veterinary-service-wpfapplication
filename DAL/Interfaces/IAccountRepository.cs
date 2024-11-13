using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        public Account GetAccountByEmail(string email);
        public Employee GetEmployeeById(string accountId);
        public Customer GetCustomerById(string accountId);
        public bool checkDuplicatePhone(string phone);
        public void AddAccount(Account account);
    }
}

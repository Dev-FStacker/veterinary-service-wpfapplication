using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerByAccountId(string accountId);
        public void AddCustomer(Customer customer);
    }
}

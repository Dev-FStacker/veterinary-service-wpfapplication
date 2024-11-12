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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService() 
        {
            customerRepository = new CustomerRepository();
        }
        public Customer GetCustomerByAccountId(string accountId) => customerRepository.GetCustomerByAccountId(accountId);
        public void AddCustomer(Customer customer) => customerRepository.AddCustomer(customer);
    }
}

using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public CustomerRepository() 
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public Customer GetCustomerByAccountId(string accountId) => _context.Customers.FirstOrDefault(c => c.AccountId == accountId);

        public void AddCustomer(Customer customer) 
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }


    }
}

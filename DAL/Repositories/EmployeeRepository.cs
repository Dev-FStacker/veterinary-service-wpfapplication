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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public EmployeeRepository() 
        {
            _context = new KoiVeterinaryServiceCenter();
        }
        public Employee GetEmployeeByAccountId(string accountId) => _context.Employees.FirstOrDefault(e => e.AccountId == accountId && e.RoleId == "R3");
    }
}

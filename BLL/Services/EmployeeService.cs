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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService() 
        {
            _employeeRepository = new EmployeeRepository();
        }
        public Employee GetEmployeeByAccountId(string accountId) => _employeeRepository.GetEmployeeByAccountId(accountId);
    }
}

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAllById(string employeeId);
        void Add(Schedule schedule);
        void Delete(Schedule schedule);
    }
}

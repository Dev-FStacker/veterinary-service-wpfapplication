using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IScheduleService
    {
        List<Schedule> GetSchedulesById(string employeeId);
        void AddSlot(Schedule schedule);
        void RemoveSlot(Schedule schedule);
    }
}

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
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repo;
        public ScheduleService()
        {
            _repo = new ScheduleRepository();
        }
        public void AddSlot(Schedule schedule) => _repo.Add(schedule);

        public void DeleteScheduleById(string scheduleId)
        {
            _repo.Delete(scheduleId);
        }

        public List<Schedule> GetSchedulesById(string employeeId) => _repo.GetAllById(employeeId);
    }
}

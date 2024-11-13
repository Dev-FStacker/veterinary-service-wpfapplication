using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public ScheduleRepository()
        {
            _context = new KoiVeterinaryServiceCenter();
        }
        public void Add(Schedule schedule)
        {
            try
            {
                if (schedule != null)
                {
                    _context.Schedules.Add(schedule);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
                if (schedule != null)
                {
                    _context.Schedules.Remove(schedule);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<Schedule>? GetAllById(string employeeId)
        {
            try
            {
                var schedules = _context.Schedules
                    .Include(s => s.Bookings)
                        .ThenInclude(b => b.BookingDetails)
                            .ThenInclude(bd => bd.Service)
                    .Include(s => s.SlotTables)
                    .Include(s => s.Bookings)
                    .ThenInclude(b => b.Customer)
                    .ThenInclude(c => c.Account)
                    .Where(s => s.EmployeeId == employeeId)
                    .ToList();
                return schedules;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Schedule GetById(string scheduleId)
        {
            try
            {
                return _context.Schedules.FirstOrDefault(s => s.ScheduleId == scheduleId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetRandomSchedule(DateOnly date, int slot)
        {
            try
            {
                var schedule = _context.Schedules
                                        .Include(s => s.SlotTables)
                                        .Where(s => s.Date == date && s.SlotTables.Any(st => st.Slot == slot))
                                        .ToList();
                if (schedule.Any())
                {
                    var random = new Random();

                    return schedule[random.Next(schedule.Count)].ScheduleId;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveSchedule()
        {
            throw new NotImplementedException();
        }
    }
}

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
                    _context.Add(schedule);
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
                var schedule = GetById(id);
                if (schedule != null)
                {
                    _context.Schedules.Remove(schedule);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;  // Re-throw the exception after logging it
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
                    .Include(s => s.Bookings)  // Ensure Bookings are loaded
                    .ThenInclude(b => b.Customer)
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
    }
}

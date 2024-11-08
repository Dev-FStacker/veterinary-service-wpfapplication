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

        public void Delete(Schedule schedule)
        {
            try
            {
                var hasBookings = _context.Bookings
                    .Any(b => b.ScheduleId == schedule.ScheduleId);
                if (hasBookings)
                {
                    throw new Exception();
                }
                _context.Remove(schedule);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Schedule>? GetAllById(string employeeId)
        {
            try
            {
                var schedules = _context.Schedules
                                    .Include(s => s.Bookings)
                                    .ThenInclude(b => b.BookingDetails)   // Include BookingDetails to access associated Service
                                    .ThenInclude(bd => bd.Service)            // Include Service within BookingDetails
                                    .Where(s => s.EmployeeId == employeeId)
                                    .ToList();
                return schedules;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

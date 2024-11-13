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
    public class BookingRepository : IBookingRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public BookingRepository()
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public void Add(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    _context.Add(booking);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddDetail(BookingDetail bookingDetail)
        {
            try
            {
                var detail = _context.BookingDetails.Add(bookingDetail);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Booking> GetAllBookingByCustomerId(string customerId)
        {
            try
            {
                return _context.Bookings.Where(b => b.CustomerId == customerId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Booking? GetBookingById(string bookingId)
        {
            try
            {
                return _context.Bookings.SingleOrDefault(b => b.BookingId == bookingId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

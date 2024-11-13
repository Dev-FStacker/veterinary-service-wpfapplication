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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService()
        {
            _bookingRepository = new BookingRepository();
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }

        public void AddDetail(BookingDetail bookingDetail)
        {
            _bookingRepository.AddDetail(bookingDetail);
        }

        public List<Booking> GetAllBookingByCustomerId(string customerId)
        {
            try
            {
                return _bookingRepository.GetAllBookingByCustomerId(customerId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Booking GetBookingById(string bookingId)
        {
            try
            {
                return _bookingRepository.GetBookingById(bookingId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveChanges()
        {
            _bookingRepository.SaveChanges();
        }
    }
}

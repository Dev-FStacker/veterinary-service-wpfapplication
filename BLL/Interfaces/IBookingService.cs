using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookingService
    {
        void AddBooking(Booking booking);
        void AddDetail(BookingDetail bookingDetail);
        List<Booking> GetAllBookingByCustomerId(string customerId);
        Booking GetBookingById(string bookingId);
        void SaveChanges();
    }
}

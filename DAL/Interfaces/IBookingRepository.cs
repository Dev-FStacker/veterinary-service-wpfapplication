using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void AddDetail(BookingDetail bookingDetail);
        List<Booking> GetAllBookingByCustomerId(string customerId);
        Booking GetBookingById(string bookingId);
        void SaveChanges();
    }
}

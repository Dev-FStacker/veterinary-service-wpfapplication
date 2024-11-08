using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BookingModel
    {
        public string ServiceName { get; set; }
        public Booking Booking { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Brush BackgroundColor { get; set; }
        public Brush ForegroundColor { get; set; }
    }
}

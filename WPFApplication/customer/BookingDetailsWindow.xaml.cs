using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApplication.customer
{
    /// <summary>
    /// Interaction logic for BookingDetailsWindow.xaml
    /// </summary>
    public partial class BookingDetailsWindow : Window
    {
        private Customer _customer;
        private readonly IBookingService _bookingService;
        public BookingDetailsWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            _bookingService = new BookingService();
            LoadBookings(customer);
        }
        private void LoadBookings(Customer customer)
        {
            try
            {
                var bookings = _bookingService.GetAllBookingByCustomerId(customer.CustomerId);
                if (bookings != null)
                {
                    BookingDataGrid.ItemsSource = bookings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedBooking = BookingDataGrid.SelectedItem as Booking;
                if (selectedBooking == null)
                {
                    MessageBox.Show("Please select a booking to mark as paid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var booking = _bookingService.GetBookingById(selectedBooking.BookingId);

                if (booking.PaymentStatus == "Paid")
                {
                    MessageBox.Show("This booking has already been marked as paid.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                booking.PaymentStatus = "Paid";
                booking.Status = "Paid";

                _bookingService.SaveChanges();

                MessageBox.Show("Payment has been successfully completed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadBookings(_customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

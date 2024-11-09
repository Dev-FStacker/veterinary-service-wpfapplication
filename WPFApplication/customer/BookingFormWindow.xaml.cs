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
    /// Interaction logic for BookingFormWindow.xaml
    /// </summary>
    public partial class BookingFormWindow : Window
    {
        private readonly IKoiService _koiService;
        public Customer _customer;
        public BookingFormWindow(Customer customer)
        {
            InitializeComponent();
            _koiService = new KoiService();
            _customer = customer;
            LoadKoiServices();
        }
        private void LoadKoiServices()
        {
            try
            {
                var services = _koiService.GetAllServices();
                foreach (var service in services)
                {
                    ServiceTypeComboBox.Items.Add(service);
                    ServiceTypeComboBox.DisplayMemberPath = "Name";
                    ServiceTypeComboBox.SelectedValuePath = "ServiceId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void ConfirmBookingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bookingId = Guid.NewGuid().ToString().Substring(0, 20);
                var customerId = _customer.CustomerId;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

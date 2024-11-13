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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApplication.admin
{
    /// <summary>
    /// Interaction logic for ServiceManagementPage.xaml
    /// </summary>
    public partial class ServiceManagementPage : Page
    {
        private readonly IKoiService _koiService;
        public ServiceManagementPage()
        {
            InitializeComponent();
            _koiService = new KoiService();
            LoadServices();
        }

        private async void LoadServices()
        {
            try
            {
                var services = _koiService.GetAllServices();
                ServicesDataGrid.ItemsSource = services;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var service = new Service
                {
                    ServiceId = ServiceIdTextBox.Text,
                    Name = ServiceNameTextBox.Text,
                    Price = decimal.Parse(ServicePriceTextBox.Text),
                    Description = ServiceDescriptionTextBox.Text,
                    Status = ServiceStatusTextBox.Text
                };

                _koiService.AddService(service);
                MessageBox.Show("Service added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServicesDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Please select a service to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedService = (Service)ServicesDataGrid.SelectedItem;
                selectedService.ServiceId = ServiceIdTextBox.Text;
                selectedService.Name = ServiceNameTextBox.Text;
                selectedService.Price = decimal.Parse(ServicePriceTextBox.Text);
                selectedService.Description = ServiceDescriptionTextBox.Text;
                selectedService.Status = ServiceStatusTextBox.Text;

                _koiService.UpdateService(selectedService);
                MessageBox.Show("Service updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating service: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a service to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedService = (Service)ServicesDataGrid.SelectedItem;

            // Check if the service is associated with any booking details
            bool hasBookings = _koiService.HasBookings(selectedService.ServiceId);

            if (hasBookings)
            {
                MessageBox.Show("This service cannot be deleted because it is associated with existing bookings.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Proceed with deletion
            _koiService.DeleteService(selectedService.ServiceId);
            MessageBox.Show("Service deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadServices();
            ClearForm();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            ServiceIdTextBox.Clear();
            ServiceNameTextBox.Clear();
            ServicePriceTextBox.Clear();
            ServiceDescriptionTextBox.Clear();
            ServiceStatusTextBox.Clear();
        }
    }
}

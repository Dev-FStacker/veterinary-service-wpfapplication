using BLL.Interfaces;
using BLL.Services;
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
        private readonly IFishService _fishService;
        public ServiceManagementPage()
        {
            InitializeComponent();
            _fishService = new FishService();
            LoadServices();
        }

        private async void LoadServices()
        {
            try
            {
                var services = await Task.Run(() => _fishService.GetAllServices());
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

        }

        private void UpdateService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private Customer getCustomer;
        private readonly IVeterinarySvService veterinaryService;
        public CustomerWindow(Customer customer)
        {
            this.getCustomer = customer;
            veterinaryService = new VeterinarySvService();
            InitializeComponent();
            visibilityItem();
        }

        private void visibilityItem() 
        {
            imgBanner.Visibility = Visibility.Visible;
            dgService.Visibility = Visibility.Collapsed;
            borderAbout.Visibility = Visibility.Collapsed;
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            imgBanner.Visibility = Visibility.Collapsed;
            borderAbout.Visibility = Visibility.Collapsed;

            dgService.Visibility = Visibility.Visible;

            dgService.ItemsSource = veterinaryService.GetAllServiceAvailable();
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            imgBanner.Visibility = Visibility.Visible;
            dgService.Visibility = Visibility.Collapsed;
            borderAbout.Visibility = Visibility.Collapsed;
        }

        private void imgLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgBanner.Visibility = Visibility.Visible;

            dgService.Visibility = Visibility.Collapsed;
            borderAbout.Visibility = Visibility.Collapsed;
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            imgBanner.Visibility = Visibility.Collapsed;
            dgService.Visibility = Visibility.Collapsed;

            borderAbout.Visibility = Visibility.Visible;
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            CustomerPanelWindow customerPanelWindow = new CustomerPanelWindow(getCustomer);


        }
    }
}

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

namespace WPFApplication.admin
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServiceManagementPage());
        }

        private void Pricing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Promotions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bookings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

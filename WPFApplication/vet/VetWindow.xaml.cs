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
using WPFApplication.vet;

namespace WPFApplication
{
    /// <summary>
    /// Interaction logic for VetWindow.xaml
    /// </summary>
    public partial class VetWindow : Window
    {
        private Employee _employee;
        public VetWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ScheduleManagementPage(_employee));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            VetProfileWindow profileWindow = new VetProfileWindow(_employee);
            profileWindow.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?",
                                              "Logout Confirmation",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }
    }
}

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

namespace WPFApplication.vet
{
    /// <summary>
    /// Interaction logic for VetProfileWindow.xaml
    /// </summary>
    public partial class VetProfileWindow : Window
    {
        private Employee _employee;

        public VetProfileWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;

            // Populate the profile information
            FullNameTextBlock.Text = $"{_employee.Firstname} {_employee.Lastname}";
            SexTextBlock.Text = _employee.Sex.HasValue ? (_employee.Sex.Value ? "Male" : "Female") : "Not specified";
            BirthdayTextBlock.Text = _employee.Birthday?.ToString("yyyy-MM-dd") ?? "Not specified";
            AddressTextBlock.Text = _employee.Address;
            StatusTextBlock.Text = _employee.Status == "1" ? "Active" : "Inactive";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
using WPFApplication.admin;
using WPFApplication.customer;

namespace WPFApplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAuthService _authService;
        public Login()
        {
            _authService = new AuthService();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            checkEmpty();
            string email = txtEmail.Text;
            string password = pwbPassword.Password;

            try
            {
                Account account = _authService.Authenticate(email, password);
                MessageBox.Show("Login successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                OpenRoleSpecificWindow(account);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void checkEmpty()
        {
            if (String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(pwbPassword.Password))
            {
                MessageBox.Show("All field empty!");
                return;
            }
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email can not empty!");
                return;
            }
            if (String.IsNullOrEmpty(pwbPassword.Password))
            {
                MessageBox.Show("Password can not empty!");
                return;
            }
        }

        private void OpenRoleSpecificWindow(Account user)
        {
            Window roleSpecificWindow;
            IAuthService authService = new AuthService();
            switch (user.GetRoleName)
            {
                case "Admin":
                    roleSpecificWindow = new AdminWindow();
                    break;
                case "Veterinarian":
                    var employee = authService.GetEmployeeById(user.AccountId);
                    roleSpecificWindow = new VetWindow(employee);
                    break;
                case "Customer":
                    var customer = authService.GetCustomerById(user.AccountId);
                    roleSpecificWindow = new CustomerPanelWindow(customer);
                    break;
                default:
                    throw new Exception("Unknown user role.");
            }
            roleSpecificWindow.Show();
        }
    }
}

using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFApplication.customer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WPFApplication.guest
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private readonly string EMAIL_PATTERN =  @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private readonly string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = pbPassword.Password;
            string confirmPassword = pbConfirmPassword.Password;

            if (checkValidEmail(email) && checkValidPassword(password, confirmPassword))
            {
                AccountCreate account = new AccountCreate() 
                {
                    email = email,
                    password = password
                };
                FillInfoWindow fillInfoWindow = new FillInfoWindow(account);
                fillInfoWindow.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Signup false!");
                return;
            }
        }

        private bool checkValidEmail(string email) 
        {
            if (String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email can not null!");
                return false;
            }
            else 
            {
                bool isValidEmail = Regex.IsMatch(email, EMAIL_PATTERN);
                if (isValidEmail == false) 
                {
                    MessageBox.Show("Email is not valid!");
                    return false;
                }
            }
            return true;
        }

        private bool checkValidPassword(string password, string confirmPassword) 
        {
            if (String.IsNullOrEmpty(password) && String.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Password and confirm password can not empty!");
                return false;
            }
            else 
            {
                bool isValidPassword = Regex.IsMatch(password, PASSWORD_PATTERN);
                if (isValidPassword == false)
                {
                    MessageBox.Show("At least one uppercase letter, one lowercase letter, one digit, and one special character, with a minimum length of 8");
                    return false;
                }
                if (password != confirmPassword) 
                {
                    MessageBox.Show("Password and confirm password was different!");
                    return false;
                }
            }
            return true;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = txtEmail.Text;
            if (String.IsNullOrEmpty(email))
            {
                txtEmail.BorderBrush = Brushes.Gray;
            }
            else 
            {
                bool isValidEmail = Regex.IsMatch(email, EMAIL_PATTERN);
                if (isValidEmail)
                {
                    txtEmail.BorderBrush = Brushes.Gray;
                }
                else 
                {
                    txtEmail.BorderBrush = Brushes.Red;
                    txtEmail.BorderThickness = new Thickness(1.2);
                }
            }
            
            
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(pbPassword.Password) && String.IsNullOrEmpty(pbConfirmPassword.Password))
            {
                pbPassword.BorderBrush = Brushes.Gray;
                pbConfirmPassword.BorderBrush = Brushes.Gray;
            }
            else
            {
                if (pbPassword.Password != pbConfirmPassword.Password)
                {
                    pbPassword.BorderBrush = Brushes.Red;
                    pbPassword.BorderThickness = new Thickness(1.2);
                    pbConfirmPassword.BorderBrush = Brushes.Red;
                    pbConfirmPassword.BorderThickness = new Thickness(1.2);
                }
                else
                {
                    pbPassword.BorderBrush = Brushes.Gray;
                    pbPassword.BorderBrush = Brushes.Gray;
                }
            }
        }
    }
}

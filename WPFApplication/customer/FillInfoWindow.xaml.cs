using BLL.Interfaces;
using BLL.Services;
using DAL.DTO;
using DAL.Models;
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

namespace WPFApplication.customer
{
    /// <summary>
    /// Interaction logic for FillInfoWindow.xaml
    /// </summary>
    public partial class FillInfoWindow : Window
    {
        private readonly string NAME_PATTERN = @"^[A-Za-z]+(\s[A-Za-z]+)*$";
        private readonly string ADDRESS_PATTERN = @"^[A-Za-z0-9\s,.-]+$";
        private readonly string PHONE_PATTERN = @"^\d{10}$";


        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        private AccountCreate getAccountCreate;
        public FillInfoWindow(AccountCreate accountCreate)
        {
            this.getAccountCreate = accountCreate;
            accountService = new AccountService();
            customerService = new CustomerService();
            InitializeComponent();
            checkExisted();
            cbMale.IsChecked = true;
        }

        private void checkExisted() 
        {
            var accountCheck = accountService.GetAccountByEmail(getAccountCreate.email);
            if (accountCheck != null)
            {
                MessageBox.Show("Email was existed");
                return;
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            bool sex = true;

            checkValidDate();
            DateOnly birthDay = DateOnly.FromDateTime(dpBirthday.SelectedDate.Value);

            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            if (cbMale.IsChecked == false)
            {
                sex = false;
            }

            if (checkValidAge(birthDay) == false) 
            {
                MessageBox.Show("Must be over 18 years old to signup!");
                return;
            }

            if (checkValidName(firstName, lastName) && checkValidAddress(address) && checkValidPhone(phone) && checkValidAge(birthDay)) 
            {
                Account account = new Account() 
                {
                    AccountId = GenerateRandomString(10),
                    Email = getAccountCreate.email,
                    Password = getAccountCreate.password,
                    PhoneNumber = phone,
                    Status = "Normal",
                    RoleId = "R4",
                    IsActive = true
                };
                accountService.AddAccount(account);
            }

            Account addedAccount = accountService.GetAccountByEmail(getAccountCreate.email);
            if (addedAccount != null) 
            {
                Customer customer = new Customer()
                {
                    CustomerId = GenerateRandomString(10),
                    AccountId = addedAccount.AccountId,
                    Firstname = firstName,
                    Lastname = lastName,
                    Sex = sex,
                    Birthday = birthDay,
                    Address = address,
                    Status = "1"
                };
                customerService.AddCustomer(customer);

                CustomerWindow customerWindow = new CustomerWindow(customer);
                customerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Add false!");
                return;
            }
        }

        private bool checkValidName(string firstName, string lastName) 
        {
            if (String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(lastName)) 
            {
                MessageBox.Show("FirstName and LastName can not empty!");
                return false;
            }
            if (String.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("FirstName can not empty!");
                return false;
            }
            if (String.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("LastName can not empty!");
                return false;
            }

            bool isValid = Regex.IsMatch(firstName, NAME_PATTERN) && Regex.IsMatch(lastName, NAME_PATTERN);
            if (isValid == false) 
            {
                MessageBox.Show("Name is not valid!");
                return false;
            }
            return true;
        }

        private bool checkValidAddress(string address) 
        {
            if (String.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address can not empty!");
                return false;
            }
            bool isValid = Regex.IsMatch(address, ADDRESS_PATTERN);
            if (isValid == false)
            {
                MessageBox.Show("Address is not valid! \n Example: 789-B Oak, Rd.");
                return false;
            }
            return true;
        }

        private bool checkValidPhone(string phone) 
        {
            if (String.IsNullOrEmpty(phone)) 
            {
                MessageBox.Show("Phone can not empty!");
                return false;
            }
            bool valid = Regex.IsMatch(phone, PHONE_PATTERN);
            if (valid == false) 
            {
                MessageBox.Show("Phone is not valid! Just accept 10 digits");
                return false;
            }

            if (accountService.checkDuplicatePhone(phone) == true) 
            {
                MessageBox.Show("Phone already existed!");
                return false;
            }
            return true;
        }

        private void checkValidDate() 
        {
            if (dpBirthday.SelectedDate == null) 
            {
                MessageBox.Show("Birthday can not null!");
                return;
            }

            
        }

        private bool checkValidAge(DateOnly birthDay)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly minDate = today.AddYears(-18);
            return birthDay <= minDate;
        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {
            cbFemale.IsChecked = false;
        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {
            cbMale.IsChecked = false;
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

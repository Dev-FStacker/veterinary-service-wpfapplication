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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApplication.customer
{
    /// <summary>
    /// Interaction logic for CustomerPanelWindow.xaml
    /// </summary>
    public partial class CustomerPanelWindow : Window
    {
        public Customer _customer;
        public CustomerPanelWindow(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            CustomerIdTextBox.Text = _customer.CustomerId;
            CustomerNameTextBox.Text = $"{_customer.Firstname} {_customer.Lastname}";
            CustomerGenderTextBox.Text = _customer.Sex.HasValue ? (_customer.Sex.Value ? "Male" : "Female") : "Not Specified";
            if (_customer.Birthday.HasValue)
            {
                CustomerDOBPicker.SelectedDate = _customer.Birthday.Value.ToDateTime(new TimeOnly(0, 0));
            }
            else
            {
                CustomerDOBPicker.SelectedDate = null; 
            }
            CustomerAddressTextBox.Text = _customer.Address;
            CustomerStatusTextBox.Text = _customer.Status;
        }

        private void BookNowButton_Click(object sender, RoutedEventArgs e)
        {
            BookingFormWindow bookingFormWindow = new BookingFormWindow(_customer);
            bookingFormWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            BookingDetailsWindow bookingDetailsWindow = new BookingDetailsWindow(_customer);
            bookingDetailsWindow.ShowDialog();
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

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPanel.Visibility == Visibility.Collapsed)
            {
                AnimateMenuVisibility(Visibility.Visible, 1, 0);
                (this.Resources["HamburgerToXStoryboard"] as Storyboard).Begin();
                Overlay.Visibility = Visibility.Visible;
            }
            else
            {
                AnimateMenuVisibility(Visibility.Collapsed, 0, -250);
                (this.Resources["HamburgerToXStoryboard"] as Storyboard).Pause();
                Overlay.Visibility = Visibility.Collapsed;
            }
        }

        private void AnimateMenuVisibility(Visibility visibility, double opacity, double translationX)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = MenuPanel.Opacity,
                To = opacity,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            MenuPanel.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            TranslateTransform translateTransform = new TranslateTransform();
            MenuPanel.RenderTransform = translateTransform;

            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = translateTransform.X,
                To = translationX,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            translateTransform.BeginAnimation(TranslateTransform.XProperty, slideAnimation);

            MenuPanel.Visibility = visibility;
        }
    }
}

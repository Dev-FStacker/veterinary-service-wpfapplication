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
        public CustomerPanelWindow()
        {
            InitializeComponent();
        }

        private void BookNowButton_Click(object sender, RoutedEventArgs e)
        {
            BookingFormWindow bookingFormWindow = new BookingFormWindow();
            bookingFormWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the menu visibility with animation
            if (MenuPanel.Visibility == Visibility.Collapsed)
            {
                AnimateMenuVisibility(Visibility.Visible, 1, 0);
                // Play Hamburger to X Animation
                (this.Resources["HamburgerToXStoryboard"] as Storyboard).Begin();
                Overlay.Visibility = Visibility.Visible;
            }
            else
            {
                AnimateMenuVisibility(Visibility.Collapsed, 0, -250);
                // Revert Hamburger to ☰ Animation
                (this.Resources["HamburgerToXStoryboard"] as Storyboard).Pause();
                Overlay.Visibility = Visibility.Collapsed;
            }
        }

        // Animate the Menu's visibility and sliding effect
        private void AnimateMenuVisibility(Visibility visibility, double opacity, double translationX)
        {
            // Animate Opacity
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = MenuPanel.Opacity,
                To = opacity,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            MenuPanel.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);

            // Animate Slide-in / Slide-out Effect
            TranslateTransform translateTransform = new TranslateTransform();
            MenuPanel.RenderTransform = translateTransform;

            DoubleAnimation slideAnimation = new DoubleAnimation
            {
                From = translateTransform.X,
                To = translationX,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            translateTransform.BeginAnimation(TranslateTransform.XProperty, slideAnimation);

            // Set final visibility
            MenuPanel.Visibility = visibility;
        }
    }
}

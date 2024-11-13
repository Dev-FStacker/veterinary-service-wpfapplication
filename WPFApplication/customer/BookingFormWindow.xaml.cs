using BLL.Interfaces;
using BLL.Services;
using DAL.Data;
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
    /// Interaction logic for BookingFormWindow.xaml
    /// </summary>
    public partial class BookingFormWindow : Window
    {
        private readonly IKoiService _koiService;
        private readonly IScheduleService _scheduleService;
        private readonly IBookingService _bookingService;
        private readonly ISlotService _slotService;
        public KoiVeterinaryServiceCenter _context = new();
        public Customer _customer;
        public BookingFormWindow(Customer customer)
        {
            InitializeComponent();
            _koiService = new KoiService();
            _scheduleService = new ScheduleService();
            _bookingService = new BookingService();
            _slotService = new SlotService();
            _customer = customer;
            LoadKoiServices();
        }
        private void LoadKoiServices()
        {
            try
            {
                var services = _koiService.GetAllServices();
                foreach (var service in services)
                {
                    ServiceTypeComboBox.Items.Add(service);
                    ServiceTypeComboBox.DisplayMemberPath = "Name";
                    ServiceTypeComboBox.SelectedValuePath = "ServiceId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void ServiceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceTypeComboBox.SelectedItem is Service selectedService)
            {
                decimal deposit = selectedService.Price * 0.1m;

                DepositAmountTextBox.Text = deposit.ToString();
            }
        }
        private void ConfirmBookingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServiceTypeComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a service.");
                    return;
                }
                if (!BookingDatePicker.SelectedDate.HasValue)
                {
                    MessageBox.Show("Please select a booking date.");
                    return;
                }
                if (PaymentMethodComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a payment method.");
                    return;
                }
                var service = ServiceTypeComboBox.SelectedItem as Service;
                var bookingId = Guid.NewGuid().ToString().Substring(0, 20);
                var customerId = _customer.CustomerId;
                var employeeId = "E3";
                var bookingDate = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value);
                var expiredDate = BookingDatePicker.SelectedDate.Value.AddDays(1);
                var deposit = DepositAmountTextBox.Text;
                var numberOfFish = 1;
                var numberOfPool = NumberOfPoolsTextBox.Text;
                var deliveryMethodId = service.ServiceDeliveryMethodId;
                var address = _customer.Address;
                var note = AdditionalNotesTextBox.Text;
                Random random = new Random();
                int distance = random.Next(1, 101);
                int distanceCostPerKm = 1000;
                decimal distanceCost = distance * distanceCostPerKm;
                decimal servicePrice = service.Price;
                decimal totalServiceCost = CalculateTotalServiceCost(servicePrice, distanceCost);
                var status = "Pending";
                var existingSchedule = _scheduleService.GetSchedulesById(employeeId)
                                       .FirstOrDefault(s => s.Date == bookingDate && s.SlotTables.Any(st => st.Slot == SlotComboBox.SelectedIndex + 1));
                var scheduleId = existingSchedule.ScheduleId;


                var slot = existingSchedule.SlotTables.FirstOrDefault(s => s.Slot == SlotComboBox.SelectedIndex + 1);
                var selectedSlot = _slotService.GetSlotById(slot.SlotTableId);
                if (selectedSlot.SlotCapacity == 0)
                {
                    MessageBox.Show("This slot is fully booked. Please choose a different date or slot.");
                    return;
                }

                var feedBackId = "FB0";

                // Retrieve only the text content of the selected payment method
                var paymentMethod = (PaymentMethodComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

                var booking = new Booking
                {
                    BookingId = bookingId,
                    CustomerId = customerId,
                    EmployeeId = employeeId,
                    BookingDate = DateTime.Parse(bookingDate.ToString()),
                    ExpiredDate = expiredDate,
                    Deposit = Decimal.Parse(deposit),
                    NumberOfFish = numberOfFish,
                    IncidentalFish = 0,
                    NumberOfPool = 0,
                    ServiceDeliveryMethodId = deliveryMethodId,
                    BookingAddress = address,
                    Distance = distance,
                    DistanceCost = distanceCost,
                    TotalServiceCost = totalServiceCost,
                    Vat = double.Parse((totalServiceCost * 0.1m).ToString()),
                    Note = note,
                    Status = status,
                    FeedbackId = feedBackId,
                    ScheduleId = scheduleId,
                    PaymentMethod = paymentMethod,
                    PaymentStatus = "Pending",
                };

                _bookingService.AddBooking(booking);

                var bookingDetail = new BookingDetail
                {
                    BookingDetailId = Guid.NewGuid().ToString().Substring(0, 20),
                    BookingId = booking.BookingId,
                    ServiceId = service.ServiceId,
                    UnitPrice = service.Price,
                    Incidental = true,
                };

                _bookingService.AddDetail(bookingDetail);


                if (selectedSlot.SlotCapacity == 0)
                {
                    selectedSlot.SlotStatus = false;
                } else
                {
                    selectedSlot.SlotCapacity = selectedSlot.SlotCapacity - 1;
                }

                selectedSlot.SlotOrdered = (selectedSlot.SlotOrdered == null) ? 1 : selectedSlot.SlotOrdered + 1;
                _slotService.SaveChanges();

                MessageBox.Show("Booking successful! Please proceed with the payment.");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ClearForm()
        {
            // Reset the form fields to their initial state
            ServiceTypeComboBox.SelectedIndex = -1;
            DepositAmountTextBox.Clear();
            NumberOfPoolsTextBox.Clear();
            PaymentMethodComboBox.SelectedIndex = -1;
            BookingDatePicker.SelectedDate = null;
        }
        private decimal CalculateTotalServiceCost(decimal servicePrice, decimal distanceCost)
        {
            return servicePrice + distanceCost;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

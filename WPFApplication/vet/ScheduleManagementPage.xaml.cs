using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Scheduler;
using System.Windows;
using BLL.Interfaces;
using BLL.Services;
using WPFApplication.common;
using Microsoft.IdentityModel.Tokens;

namespace WPFApplication.vet
{
    public partial class ScheduleManagementPage : Page
    {
        private readonly IScheduleService _scheduleService;
        private readonly ISlotService _slotService;
        public Employee _employee;
        public ObservableCollection<AppointmentModel> Appointments { get; set; }
        public ScheduleManagementPage(Employee employee)
        {
            InitializeComponent();
            _scheduleService = new ScheduleService();
            _slotService = new SlotService();
            _employee = employee;
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            Appointments = new ObservableCollection<AppointmentModel>();
            IScheduleService scheduleService = new ScheduleService();
            try
            {
                var schedules = scheduleService.GetSchedulesById(_employee.EmployeeId);

                foreach (var schedule in schedules)
                {
                    foreach (var slotTable in schedule.SlotTables)
                    {
                        AppointmentModel appointmentModel = new AppointmentModel();
                        var (fromTime, toTime) = GetTimeRangeBySlot((int)slotTable.Slot);

                        var fromDateTime = new DateTime(schedule.Date.Year, schedule.Date.Month, schedule.Date.Day, fromTime.Hour, fromTime.Minute, 0);
                        var toDateTime = new DateTime(schedule.Date.Year, schedule.Date.Month, schedule.Date.Day, toTime.Hour, toTime.Minute, 0);
                        appointmentModel.From = fromDateTime;
                        appointmentModel.To = toDateTime;
                        appointmentModel.BackgroundColor = Brushes.Green;
                        appointmentModel.ForegroundColor = Brushes.White;
                        appointmentModel.Title = "Available To Book";

                        if (slotTable.SlotOrdered > 0)
                        {
                            appointmentModel.Title = "Booked";
                            appointmentModel.BackgroundColor = Brushes.Red;
                        }
                        else if (slotTable.SlotOrdered == null || slotTable.SlotOrdered == 0)
                        {
                            appointmentModel.Title = "Available To Book";
                        }
                        Appointments.Add(appointmentModel);
                    }
                }
                Schedule.ItemsSource = null;
                Schedule.ItemsSource = Appointments;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
                return;
            }
        }


        private void Schedule_CellTapped(object sender, CellTappedEventArgs e)
        {
            try
            {
                var selectedDateTime = e.DateTime;
                var selectedDate = DateOnly.FromDateTime(selectedDateTime.Date);
                var selectedTime = selectedDateTime.TimeOfDay;

                var selectedTimeOnly = new TimeOnly(selectedTime.Hours, selectedTime.Minutes, selectedTime.Seconds);

                var slots = new[]
                {
                    new { Slot = "Slot1", Start = new TimeOnly(7, 0), End = new TimeOnly(9, 0), SlotNumber = 1 },
                    new { Slot = "Slot2", Start = new TimeOnly(10, 0), End = new TimeOnly(12, 0), SlotNumber = 2 },
                    new { Slot = "Slot3", Start = new TimeOnly(13, 0), End = new TimeOnly(15, 0), SlotNumber = 3 },
                    new { Slot = "Slot4", Start = new TimeOnly(16, 0), End = new TimeOnly(18, 0), SlotNumber = 4 }
                };

                var matchingSlot = slots.FirstOrDefault(slot =>
                    selectedTimeOnly >= slot.Start && selectedTimeOnly < slot.End);

                if (matchingSlot != null)
                {
                    var existingSlot = _scheduleService.GetSchedulesById(_employee.EmployeeId)
                                        .FirstOrDefault(s => s.Date == selectedDate && s.SlotTables.Any(st => st.Slot == matchingSlot.SlotNumber));
                    if (existingSlot != null)
                    {
                        var checkSlot = existingSlot.SlotTables.SingleOrDefault(s => s.Slot == matchingSlot.SlotNumber);
                        if (checkSlot.SlotOrdered == null)
                        {
                            var slot = existingSlot.SlotTables.SingleOrDefault(s => s.Slot == matchingSlot.SlotNumber);

                            if (slot != null)
                            {
                                var result = MessageBox.Show($"Are you sure you want to delete the free time slot {matchingSlot.Slot} on {selectedDateTime}?",
                                 "Confirm Deletion",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        _slotService.RemoveSlot(slot.SlotTableId);
                                        MessageBox.Show($"The free time slot {matchingSlot.Slot} on {selectedDateTime} has been deleted.");
                                        LoadAppointments();
                                        return;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred while deleting the slot: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Deletion cancelled.", "Cancellation", MessageBoxButton.OK, MessageBoxImage.Information);
                                    return;
                                }
                            }
                        }

                        if (existingSlot.Bookings != null && existingSlot.Bookings.Any())
                        {
                            BookingDetailsStackPanel.Children.Clear();
                            var bookingDetailsList = new List<string>();
                            foreach (var booking in existingSlot.Bookings)
                            {
                                var customerName = booking.Customer.Firstname + " " + booking.Customer.Lastname;
                                var bookingDate = booking.BookingDate.ToString("yyyy-MM-dd HH:mm");
                                var address = booking.BookingAddress;
                                var phoneNumber = booking.Customer.Account.PhoneNumber;

                                foreach (var detail in booking.BookingDetails)
                                {
                                    var serviceName = detail.Service?.Name ?? "No Service";

                                    StackPanel bookingPanel = new StackPanel
                                    {
                                        Margin = new Thickness(0, 10, 0, 10),
                                        Orientation = Orientation.Vertical
                                    };

                                    TextBlock customerNameBlock = new TextBlock
                                    {
                                        Text = $"Customer: {customerName}",
                                        FontSize = 14,
                                        FontWeight = FontWeights.Bold,
                                        Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51)) // Dark Gray
                                    };
                                    bookingPanel.Children.Add(customerNameBlock);

                                    TextBlock bookingDateBlock = new TextBlock
                                    {
                                        Text = $"Date: {bookingDate}",
                                        FontSize = 14,
                                        Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85)) // Medium Gray
                                    };
                                    bookingPanel.Children.Add(bookingDateBlock);

                                    TextBlock serviceBlock = new TextBlock
                                    {
                                        Text = $"Service: {serviceName}",
                                        FontSize = 14,
                                        Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85))
                                    };
                                    bookingPanel.Children.Add(serviceBlock);

                                    TextBlock addressBlock = new TextBlock
                                    {
                                        Text = $"Address: {address}",
                                        FontSize = 14,
                                        Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85))
                                    };
                                    bookingPanel.Children.Add(addressBlock);

                                    TextBlock phoneNumberBlock = new TextBlock
                                    {
                                        Text = $"Phone: {phoneNumber}",
                                        FontSize = 14,
                                        Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85))
                                    };
                                    bookingPanel.Children.Add(phoneNumberBlock);

                                    BookingDetailsStackPanel.Children.Add(bookingPanel);
                                }
                            }

                            DetailsPanel.Visibility = Visibility.Visible;
                            return;
                        }
                    }

                    if (selectedDate < DateOnly.FromDateTime(DateTime.Today))
                    {
                        MessageBox.Show("You cannot add a time slot for a past date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    var confirmation = MessageBox.Show($"Do you want to add a free time slot {matchingSlot.Slot} for {selectedDateTime}?",
                                                       "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (confirmation == MessageBoxResult.Yes)
                    {

                        var existingSchedule = _scheduleService.GetSchedulesById(_employee.EmployeeId)
                                                                .FirstOrDefault(s => s.Date == selectedDate);
                        if (existingSchedule == null)
                        {
                            var newSlot = new Schedule
                            {
                                ScheduleId = Guid.NewGuid().ToString().Substring(0, 20),
                                EmployeeId = _employee.EmployeeId,
                                Date = selectedDate,
                                Status = "Available",
                                Note = "Available"
                            };
                            _scheduleService.AddSlot(newSlot);
                            var slotTable = new SlotTable
                            {
                                SlotTableId = Guid.NewGuid().ToString().Substring(0, 20),
                                ScheduleId = newSlot.ScheduleId,
                                Slot = matchingSlot.SlotNumber,
                                SlotCapacity = 5,
                                SlotStatus = true
                            };
                            _slotService.AddSlot(slotTable);
                        }
                        else
                        {
                            var slotTable = new SlotTable
                            {
                                SlotTableId = Guid.NewGuid().ToString().Substring(0, 20),
                                ScheduleId = existingSchedule.ScheduleId,
                                Slot = matchingSlot.SlotNumber,
                                SlotCapacity = 5,
                                SlotStatus = true
                            };
                            _slotService.AddSlot(slotTable);
                        }

                        MessageBox.Show($"Free time slot {matchingSlot.Slot} added for {selectedDateTime}");
                        LoadAppointments();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("This time is not part of the available slots.");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error saving schedule: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private (TimeOnly FromTime, TimeOnly ToTime) GetTimeRangeBySlot(int slotNumber)
        {
            switch (slotNumber)
            {
                case 1:
                    return (new TimeOnly(7, 0), new TimeOnly(9, 0));
                case 2:
                    return (new TimeOnly(10, 0), new TimeOnly(12, 0));
                case 3:
                    return (new TimeOnly(13, 0), new TimeOnly(15, 0));
                case 4:
                    return (new TimeOnly(16, 0), new TimeOnly(18, 0));
                default:
                    MessageBox.Show($"Invalid slot number encountered: {slotNumber}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentOutOfRangeException(nameof(slotNumber), $"Invalid slot number: {slotNumber}");
            }
        }
        private void CloseDetailsPanel(object sender, RoutedEventArgs e)
        {
            BookingDetailsStackPanel.Children.Clear();
            DetailsPanel.Visibility = Visibility.Collapsed;
        }

    }
}

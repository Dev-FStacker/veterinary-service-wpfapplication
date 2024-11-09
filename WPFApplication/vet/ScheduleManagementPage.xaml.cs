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

        private async void LoadAppointments()
        {
            Appointments = new ObservableCollection<AppointmentModel>();
            try
            {
                var schedules = await Task.Run(() => _scheduleService.GetSchedulesById(_employee.EmployeeId));

                foreach (var schedule in schedules)
                {
                    foreach (var slotTable in schedule.SlotTables)
                    {
                        var (fromTime, toTime) = GetTimeRangeBySlot((int)slotTable.Slot);

                        var fromDateTime = new DateTime(schedule.Date.Year, schedule.Date.Month, schedule.Date.Day, fromTime.Hour, fromTime.Minute, 0);
                        var toDateTime = new DateTime(schedule.Date.Year, schedule.Date.Month, schedule.Date.Day, toTime.Hour, toTime.Minute, 0);

                        var appointment = new AppointmentModel
                        {
                            From = fromDateTime,
                            To = toDateTime,
                            BackgroundColor = (schedule.Status == "Available" || schedule.Status == "Active") ? Brushes.Green : Brushes.Orange,
                            ForegroundColor = Brushes.White,
                            ServiceName = "Available To Book"
                        };

                        if (schedule.Bookings != null && schedule.Bookings.Any())
                        {
                            foreach (var booking in schedule.Bookings)
                            {
                                foreach (var bookingDetail in booking.BookingDetails)
                                {
                                    if (!string.IsNullOrEmpty(bookingDetail.Service?.Name))
                                    {
                                        appointment.ServiceName = bookingDetail.Service.Name;
                                        break;
                                    }
                                }
                            }
                        }
                        Appointments.Add(appointment);
                    }
                }

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
                    new { Slot = "Slot1", Start = new TimeOnly(7, 0), End = new TimeOnly(9, 15), SlotNumber = 1 },
                    new { Slot = "Slot2", Start = new TimeOnly(9, 30), End = new TimeOnly(11, 45), SlotNumber = 2 },
                    new { Slot = "Slot3", Start = new TimeOnly(13, 0), End = new TimeOnly(15, 15), SlotNumber = 3 },
                    new { Slot = "Slot4", Start = new TimeOnly(15, 30), End = new TimeOnly(17, 15), SlotNumber = 4 }
                };

                var matchingSlot = slots.FirstOrDefault(slot =>
                    selectedTimeOnly >= slot.Start && selectedTimeOnly <= slot.End);

                if (matchingSlot != null)
                {
                    var existingSlot = _scheduleService.GetSchedulesById(_employee.EmployeeId)
                                        .FirstOrDefault(s => s.Date == selectedDate && s.SlotTables.Any(st => st.Slot == matchingSlot.SlotNumber));
                    if (existingSlot != null)
                    {

                        if (existingSlot.Bookings != null && existingSlot.Bookings.Any())
                        {
                            var schedules =_scheduleService.GetSchedulesById(_employee.EmployeeId);
                            var bookingDetailsList = new List<string>();
                            foreach (var schedule in schedules)
                            {
                                foreach (var booking in schedule.Bookings)
                                {
                                    var customerName = booking.Customer.Firstname + " " + booking.Customer.Lastname;
                                    var bookingDate = booking.BookingDate.ToString("yyyy-MM-dd HH:mm");
                                    var address = booking.BookingAddress;
                                    var phoneNumber = booking.Customer.Account.PhoneNumber;
                                    foreach (var detail in booking.BookingDetails)
                                    {
                                        var serviceName = detail.Service?.Name ?? "No Service";
                                        bookingDetailsList.Add($"Customer: {customerName}, Date: {bookingDate}, Service: {serviceName}, Address: {address}, Phone: {phoneNumber}");
                                    }
                                }
                            }

                            BookingDetailsListBox.ItemsSource = bookingDetailsList;

                            DetailsPanel.Visibility = Visibility.Visible;
                            return;
                        } else
                        {
                            var confirmationDelete = MessageBox.Show($"A time slot for {matchingSlot.Slot} on {selectedDate} already exists. Do you want to delete the existing booking?",
                                      "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            if (confirmationDelete == MessageBoxResult.Yes)
                            {


                                ISlotService slotService = new SlotService();
                                IScheduleService scheduleService = new ScheduleService();

                                foreach (var slot in existingSlot.SlotTables.ToList())
                                {
                                    slotService.RemoveSlot(slot.SlotTableId);
                                }

                                scheduleService.RemoveSlot(existingSlot.ScheduleId);

                                MessageBox.Show($"The free time slot {matchingSlot.Slot} on {selectedDateTime} has been deleted.");
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        
                    }
                    var confirmation = MessageBox.Show($"Do you want to add a free time slot {matchingSlot.Slot} for {selectedDateTime}?",
                                                       "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (confirmation == MessageBoxResult.Yes)
                    {
                        var newSlot = new Schedule
                        {
                            ScheduleId = Guid.NewGuid().ToString().Substring(0, 20),
                            EmployeeId = _employee.EmployeeId,
                            Date = selectedDate,
                            Status = "Available",
                            Note = $"Available for {matchingSlot.Slot}"
                        };
                        _scheduleService.AddSlot(newSlot);
                        var slotTable = new SlotTable
                        {
                            SlotTableId = Guid.NewGuid().ToString().Substring(0, 20),
                            ScheduleId = newSlot.ScheduleId,
                            Slot = matchingSlot.SlotNumber,
                            SlotStatus = true
                        };
                        _slotService.AddSlot(slotTable);
                        MessageBox.Show($"Free time slot {matchingSlot.Slot} added for {selectedDateTime}");
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
            finally
            {
                LoadAppointments();
            }
        }

        private (TimeOnly FromTime, TimeOnly ToTime) GetTimeRangeBySlot(int slotNumber)
        {
            switch (slotNumber)
            {
                case 1:
                    return (new TimeOnly(7, 0), new TimeOnly(9, 15));
                case 2:
                    return (new TimeOnly(9, 30), new TimeOnly(11, 45));
                case 3:
                    return (new TimeOnly(12, 30), new TimeOnly(14, 45));
                case 4:
                    return (new TimeOnly(15, 0), new TimeOnly(17, 15));
                default:
                    MessageBox.Show($"Invalid slot number encountered: {slotNumber}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentOutOfRangeException(nameof(slotNumber), $"Invalid slot number: {slotNumber}");
            }
        }
        private void CloseDetailsPanel(object sender, RoutedEventArgs e)
        {
            DetailsPanel.Visibility = Visibility.Collapsed;
            BookingDetailsListBox.ItemsSource = null;
        }

    }
}

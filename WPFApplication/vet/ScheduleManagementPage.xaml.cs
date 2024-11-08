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
        public ObservableCollection<AppointmentModel> Appointments { get; set; }
        public ScheduleManagementPage()
        {
            InitializeComponent();
            _scheduleService = new ScheduleService();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            Appointments = new ObservableCollection<AppointmentModel>();

            try
            {
                var schedules = _scheduleService.GetSchedulesById("E3"); 

                foreach (var schedule in schedules)
                {
                    var appointment = new AppointmentModel
                    {
                        From = schedule.Date.ToDateTime(new TimeOnly(7, 0)),
                        To = schedule.Date.ToDateTime(new TimeOnly(17, 0)),   
                        BackgroundColor = (schedule.Status == "Available" || schedule.Status == "Active") ? Brushes.Blue : Brushes.Red,
                        ForegroundColor = Brushes.White,
                        ServiceName = "Available"
                    };

                    // Nếu có booking, in ra thông tin service của booking
                    if (schedule.Bookings != null && schedule.Bookings.Any())
                    {
                        foreach (var booking in schedule.Bookings)
                        {
                            foreach (var bookingDetail in booking.BookingDetails)
                            {
                                appointment.ServiceName = !string.IsNullOrEmpty(bookingDetail.Service?.Name) ? bookingDetail.Service.Name : "Available";
                            }
                        }
                    }

                    Appointments.Add(appointment);
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

                // Define the time slots
                var slots = new[]
                {
                    new { Slot = "Slot1", Start = new TimeOnly(7, 0), End = new TimeOnly(9, 15) },
                    new { Slot = "Slot2", Start = new TimeOnly(9, 30), End = new TimeOnly(11, 45) },
                    new { Slot = "Slot3", Start = new TimeOnly(13, 0), End = new TimeOnly(15, 15) },
                    new { Slot = "Slot4", Start = new TimeOnly(15, 30), End = new TimeOnly(17, 15) }
                };

                var matchingSlot = slots.FirstOrDefault(slot =>
                    selectedTimeOnly >= slot.Start && selectedTimeOnly <= slot.End);

                if (matchingSlot != null)
                {
                    var newSlot = new Schedule
                    {
                        ScheduleId = Guid.NewGuid().ToString().Substring(0, 20),
                        EmployeeId = "E3",
                        Date = selectedDate,
                        Status = "Available",
                        Note = $"Available for {matchingSlot.Slot}"
                    };

                    _scheduleService.AddSlot(newSlot);
                    MessageBox.Show($"Free time slot {matchingSlot.Slot} added for {selectedDateTime}");
                }
                else
                {
                    MessageBox.Show("This time is not part of the available slots.");
                }

                LoadAppointments();
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
    }
}

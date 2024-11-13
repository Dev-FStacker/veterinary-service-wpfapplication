using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class KoiServiceRepository : IKoiServiceRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;

        public KoiServiceRepository()
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        // Get all services
        public List<Service> GetAll()
        {
            try
            {
                var services = _context.Services.Include(s => s.ServiceDeliveryMethod).ToList();
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read data from the service.", ex);
            }
        }

        // Get service by ID
        public Service GetById(string id)
        {
            try
            {
                var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve service with ID {id}.", ex);
            }
        }

        // Add a new service
        public void Add(Service service)
        {
            try
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add service.", ex);
            }
        }

        // Update an existing service
        public void Update(Service service)
        {
            try
            {
                var existingService = _context.Services.FirstOrDefault(s => s.ServiceId == service.ServiceId);
                if (existingService != null)
                {
                    existingService.Name = service.Name;
                    existingService.Price = service.Price;
                    existingService.Description = service.Description;
                    existingService.Status = service.Status;
                    existingService.ServiceDeliveryMethodId = service.ServiceDeliveryMethodId;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"Service with ID {service.ServiceId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update service.", ex);
            }
        }

        // Delete a service by ID
        public void Delete(string id)
        {
            try
            {
                var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
                if (service != null)
                {
                    _context.Services.Remove(service);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"Service with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete service.", ex);
            }
        }

        public bool HasBookings(string serviceId)
        {
            try
            {
                return _context.BookingDetails.Any(bd => bd.ServiceId == serviceId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

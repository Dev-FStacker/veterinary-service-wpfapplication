using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class KoiService : IKoiService
    {
        private readonly IKoiServiceRepository _koiServiceRepository;

        public KoiService()
        {
            _koiServiceRepository = new KoiServiceRepository();
        }

        // Get all services
        public List<Service> GetAllServices()
        {
            try
            {
                var services = _koiServiceRepository.GetAll();
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get data from service.", ex);
            }
        }

        // Get service by ID
        public Service GetServiceById(string id)
        {
            try
            {
                var service = _koiServiceRepository.GetById(id);
                if (service == null)
                {
                    throw new Exception($"Service with ID {id} not found.");
                }
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve service.", ex);
            }
        }

        // Add a new service
        public void AddService(Service service)
        {
            try
            {
                _koiServiceRepository.Add(service);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add service.", ex);
            }
        }

        // Update an existing service
        public void UpdateService(Service service)
        {
            try
            {
                _koiServiceRepository.Update(service);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update service.", ex);
            }
        }

        // Delete a service by ID
        public void DeleteService(string id)
        {
            try
            {
                _koiServiceRepository.Delete(id);
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
                return _koiServiceRepository.HasBookings(serviceId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking for bookings", ex);
            }
        }
    }
}

using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FishService : IFishService
    {
        private readonly IFishRepository _fishRepository;
        public FishService()
        {
            _fishRepository = new FishRepository();
        }

        public List<Service> GetAllServices()
        {
            try
            {
                var services = _fishRepository.GetAll();
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get data from service", ex);
            }
        }
    }
}

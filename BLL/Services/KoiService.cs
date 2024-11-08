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
    public class KoiService : IKoiService
    {
        private readonly IKoiServiceRepository _koiServiceRepository;
        public KoiService()
        {
            _koiServiceRepository = new KoiServiceRepository();
        }

        public List<Service> GetAllServices()
        {
            try
            {
                var services = _koiServiceRepository.GetAll();
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get data from service", ex);
            }
        }
    }
}

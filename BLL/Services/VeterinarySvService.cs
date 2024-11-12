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
    public class VeterinarySvService : IVeterinarySvService
    {
        private readonly IVeterinarySvRepository veterinarySvRepository;

        public VeterinarySvService() 
        {
            veterinarySvRepository = new VeterinarySvRepository();
        }
        public List<Service> GetAllServiceAvailable() => veterinarySvRepository.GetAllServiceAvailable();
    }
}

using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KoiServiceRepository : IKoiServiceRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public KoiServiceRepository()
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public List<Service>? GetAll()
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
    }
}

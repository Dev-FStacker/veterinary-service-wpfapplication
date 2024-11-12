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
    public class VeterinarySvRepository : IVeterinarySvRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public VeterinarySvRepository() 
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public List<Service> GetAllServiceAvailable() => _context.Services.Include(d => d.ServiceDeliveryMethod)
                                                                 .Where(s => s.Status == "1")
                                                                 .ToList();
    }
}

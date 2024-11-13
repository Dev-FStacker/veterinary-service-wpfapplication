using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKoiServiceRepository
    {
        List<Service> GetAll();
        Service GetById(string id);
        void Add(Service service);
        void Update(Service service);
        void Delete(string id);
        bool HasBookings(string serviceId);
    }
}

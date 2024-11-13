using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKoiService
    {
        List<Service> GetAllServices();
        Service GetServiceById(string id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(string id);
        bool HasBookings(string serviceId);
    }
}

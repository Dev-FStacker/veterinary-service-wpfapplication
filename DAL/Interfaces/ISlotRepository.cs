using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISlotRepository
    {
        List<SlotTable> GetAllById(string scheduleId);
        SlotTable GetById(string id);
        void Add(SlotTable slot);
        void Delete(string id);
        void SaveSlot();
    }
}

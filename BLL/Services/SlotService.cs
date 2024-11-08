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
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        public SlotService()
        {
            _slotRepository = new SlotRepository();
        }

        public void AddSlot(SlotTable slot) => _slotRepository.Add(slot);

        public List<SlotTable> GetSlotsById(string scheduleId)
        {
            return _slotRepository.GetAllById(scheduleId);
        }
        public void RemoveSlot(string id) => _slotRepository.Delete(id);
        
    }
}

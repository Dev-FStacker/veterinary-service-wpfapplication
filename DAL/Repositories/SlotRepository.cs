using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly KoiVeterinaryServiceCenter _context;
        public SlotRepository()
        {
            _context = new KoiVeterinaryServiceCenter();
        }

        public void Add(SlotTable slot)
        {
            try
            {
                if (slot != null)
                {
                    _context.SlotTables.Add(slot);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(string id)
        {
            try
            {
                var slot = GetById(id);
                if (slot != null)
                {
                    _context.SlotTables.Remove(slot);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public List<SlotTable> GetAllById(string scheduleId)
        {
            return _context.SlotTables
                           .Where(s => s.ScheduleId == scheduleId)
                           .ToList();
        }

        public SlotTable GetById(string id)
        {
            return _context.SlotTables.FirstOrDefault(s => s.SlotTableId == id);
        }

        public void SaveSlot()
        {
            throw new NotImplementedException();
        }
    }
}

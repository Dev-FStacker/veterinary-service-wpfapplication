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

        public List<SlotTable>? GetAllById(string scheduleId)
        {
            KoiVeterinaryServiceCenter context = new KoiVeterinaryServiceCenter();
            var slots = context.SlotTables.Where(s => s.ScheduleId == scheduleId).ToList();
            return slots;
        }

        public SlotTable? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Slot ID cannot be null or empty.", nameof(id));

            return _context.SlotTables
                .FirstOrDefault(s => s.SlotTableId == id);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving changes.", ex);
            }
        }

        public void SaveSlot()
        {
            throw new NotImplementedException();
        }
    }
}

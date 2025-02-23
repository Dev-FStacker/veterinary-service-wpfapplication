﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISlotService
    {
        List<SlotTable>? GetSlotsByScheduleId(string scheduleId);
        void AddSlot(SlotTable slot);
        void RemoveSlot(string id);
        SlotTable GetSlotById(string id);
        void SaveChanges();
    }
}

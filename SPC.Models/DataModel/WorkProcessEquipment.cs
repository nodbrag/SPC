using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class WorkProcessEquipment
    {
        public int WorkProcessEquipmentId { get; set; }
        public int WorkProcessId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
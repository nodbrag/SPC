using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class EquipmentTag
    {
        public int EquipmentTagId { get; set; }
        public int TagId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual TagItem Tag { get; set; }
    }
}
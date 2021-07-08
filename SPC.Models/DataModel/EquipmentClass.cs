using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class EquipmentClass
    {
        public EquipmentClass()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int EquipmentClassId { get; set; }
        public string EquipmentClassCode { get; set; }
        public string EquipmentClassName { get; set; }
        public string ParentId { get; set; }
        public string Memo { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
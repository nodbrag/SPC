using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentTag = new HashSet<EquipmentTag>();
            Task = new HashSet<Task>();
            WorkProcessEquipment = new HashSet<WorkProcessEquipment>();
        }

        public int EquipmentId { get; set; }
        public int EquipmentClassId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentCode { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentSpec { get; set; }
        public byte[] EquipmentImage { get; set; }
        public string Manufacturer { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int LifeCircleYear { get; set; }
        public decimal StandCapacity { get; set; }
        public string Memo { get; set; }

        public virtual EquipmentClass EquipmentClass { get; set; }
        public virtual ICollection<EquipmentTag> EquipmentTag { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<WorkProcessEquipment> WorkProcessEquipment { get; set; }
    }
}
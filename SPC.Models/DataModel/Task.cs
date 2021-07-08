using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Task
    {
        public Task()
        {
            InspectionOrder = new HashSet<InspectionOrder>();
            VinspectionOrder = new HashSet<VinspectionOrder>();
            VtaskDefectReport = new HashSet<VtaskDefectReport>();
        }

        public int TaskId { get; set; }
        public int ProductId { get; set; }
        public int WorkProcessId { get; set; }
        public int EquipmentId { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string UserDefine1 { get; set; }
        public string UserDefine2 { get; set; }
        public string UserDefine3 { get; set; }
        public string UserDefine4 { get; set; }
        public string UserDefine5 { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Product Product { get; set; }
        public virtual WorkProcess WorkProcess { get; set; }
        public virtual ICollection<InspectionOrder> InspectionOrder { get; set; }
        public virtual ICollection<VinspectionOrder> VinspectionOrder { get; set; }
        public virtual ICollection<VtaskDefectReport> VtaskDefectReport { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class DefectItem
    {
        public DefectItem()
        {
            WorkProcessDefect = new HashSet<WorkProcessDefect>();
            VtaskDefectReport = new HashSet<VtaskDefectReport>();
        }

        public int DefectItemId { get; set; }
        public string DefectItemCode { get; set; }
        public string DefectItemName { get; set; }
        public string Memo { get; set; }

        public virtual ICollection<WorkProcessDefect> WorkProcessDefect { get; set; }
        public virtual ICollection<VtaskDefectReport> VtaskDefectReport { get; set; }
    }
}
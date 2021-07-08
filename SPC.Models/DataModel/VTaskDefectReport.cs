using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Models.DataModel
{
    public class VtaskDefectReport
    {
        public int VtaskDefectReportId { get; set; }
        public int TaskId { get; set; }
        public int DefectItemId { get; set; }
        public int DefectItemNum { get; set; }

        public virtual DefectItem DefectItem { get; set; }
        public virtual Task Task { get; set; }
    }
}

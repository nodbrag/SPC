using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class WorkProcessDefect
    {
        public int WorkProcessDefectId { get; set; }
        public int DefectItemId { get; set; }
        public int WorkProcessId { get; set; }

        public virtual DefectItem DefectItem { get; set; }
        public virtual WorkProcess WorkProcess { get; set; }
    }
}
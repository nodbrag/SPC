using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class WorkProcess
    {
        public WorkProcess()
        {
            InspectionParam = new HashSet<InspectionParam>();
            Task = new HashSet<Task>();
            WorkProcessDefect = new HashSet<WorkProcessDefect>();
        }

        public int WorkProcessId { get; set; }
        public string WorkProcessCode { get; set; }
        public string WorkProcessName { get; set; }
        public string Memo { get; set; }

        public virtual ICollection<InspectionParam> InspectionParam { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<WorkProcessDefect> WorkProcessDefect { get; set; }
    }
}
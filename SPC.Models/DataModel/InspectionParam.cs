using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class InspectionParam
    {
        public int InspectionParamId { get; set; }
        public int ProductId { get; set; }
        public int WorkProcessId { get; set; }
        public int ParameterId { get; set; }

        public virtual Parameter Parameter { get; set; }
        public virtual Product Product { get; set; }
        public virtual WorkProcess WorkProcess { get; set; }
    }
}
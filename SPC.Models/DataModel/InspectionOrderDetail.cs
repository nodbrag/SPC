using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class InspectionOrderDetail
    {
        public long InspectionOrderDetailId { get; set; }
        public long InspectionOrderId { get; set; }
        public string ParameterValue { get; set; }
        public int ParameterId { get; set; }

        public virtual InspectionOrder InspectionOrder { get; set; }
        public virtual Parameter Parameter { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class InspectionOrder
    {
        public InspectionOrder()
        {
            InspectionOrderDetail = new HashSet<InspectionOrderDetail>();
        }

        public long InspectionOrderId { get; set; }
        public int TaskId { get; set; }
        public string ProductSn { get; set; }
        public DateTime OrderDateTime { get; set; }

        public virtual Task Task { get; set; }
        public virtual ICollection<InspectionOrderDetail> InspectionOrderDetail { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class VinspectionOrder
    {
        public VinspectionOrder()
        {
            VinspectionOrderDetail = new HashSet<VinspectionOrderDetail>();
        }

        public long VinspectionOrderId { get; set; }
        public int TaskId { get; set; }
        public string ProductSn { get; set; }
        public DateTime OrderDateTime { get; set; }

        public virtual Task Task { get; set; }
        public virtual ICollection<VinspectionOrderDetail> VinspectionOrderDetail { get; set; }
    }
}
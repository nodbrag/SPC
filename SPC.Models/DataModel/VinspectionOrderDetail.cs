using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class VinspectionOrderDetail
    {
        public long VinspectionOrderDetailId { get; set; }
        public long VinspectionOrderId { get; set; }
        public int DefectItemId { get; set; }
        public double EuclidDistance { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual VinspectionOrder VinspectionOrder { get; set; }
    }
}
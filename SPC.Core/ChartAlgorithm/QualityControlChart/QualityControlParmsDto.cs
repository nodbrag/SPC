using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.QualityControlChart
{
    public class QualityControlParmsDto
    {
        /// <summary>
        /// 均值
        /// </summary>
        public double MeanValue { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public double MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double MaxValue { get; set; }
        /// <summary>
        /// 极差值
        /// </summary>
        public double RangeValue { get; set; }
        /// <summary>
        /// 标准差值
        /// </summary>
        public double StandardDeviationValue { get; set; }
    }
}

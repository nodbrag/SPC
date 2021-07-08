using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.Histogram
{
    public class HistogramParamsDto
    {
        /// <summary>
        /// 下边界值
        /// </summary>
        public double LValue { get; set; }
        /// <summary>
        /// 区域中间值
        /// </summary>
        public double CValue { get; set; }
        /// <summary>
        /// 上边界值
        /// </summary>
        public double UValue { get; set; }
        /// <summary>
        /// 符合区域内的数量值
        /// </summary>
        public double Number { get; set; }
    }
}

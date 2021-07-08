using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.ChartAlgorithm;

namespace SPC.Core.ChartAlgorithm.Histogram
{
    public class HistogramDto
    {
        /// <summary>
        /// X 数值
        /// </summary>
        public List<double> XValue { get; set; }
        /// <summary>
        /// Y 数值
        /// </summary>
        public List<double> YValue { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public double MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// CPK
        /// </summary>
        public CPKDto cpk { get; set; }
        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName { get; set; }

        public HistogramDto()
        {
            XValue = new List<double>();
            YValue = new List<double>();
            cpk = new CPKDto();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.ChartAlgorithm.Histogram;

namespace SPC.Core.ChartAlgorithm.QualityControlChart
{
    public class QualityControlDto
    {
        /// <summary>
        /// 均值图中心线值
        /// </summary>
        public double MeanCL { get; set; }
        /// <summary>
        /// 均值图上限线值
        /// </summary>
        public double MeanUCL { get; set; }
        /// <summary>
        ///均值图下限值
        /// </summary>
        public double MeanLCL { get; set; }
        /// <summary>
        /// 极差图中心线值
        /// </summary>
        public double RangeCL { get; set; }
        /// <summary>
        /// 极差图上限值
        /// </summary>
        public double RangeUCL { get; set; }
        /// <summary>
        /// 极差图下限值
        /// </summary>
        public double RangeLCL { get; set; }
        /// <summary>
        /// 样本图中心线值
        /// </summary>
        public double SampleCL { get; set; }
        /// <summary>
        /// 样本图上限值
        /// </summary>
        public double SampleUCL { get; set; }
        /// <summary>
        /// 样本下限值
        /// </summary>
        public double SampleLCL { get; set; }
        /// <summary>
        /// 均值列表值
        /// </summary>
        public List<double> MeanValues { get; set; }
        /// <summary>
        /// 极差列表值
        /// </summary>
        public List<double> RangeValues { get; set; }

        /// <summary>
        /// 样本列表值
        /// </summary>
        public Dictionary<int, List<double>> SampleValues { get; set; }
        /// <summary>
        /// CPK
        /// </summary>
        public HistogramDto histogram { get; set; }

        public QualityControlDto()
        {
            MeanValues = new List<double>();
            RangeValues = new List<double>();
            SampleValues = new Dictionary<int, List<double>>();
            histogram = new HistogramDto();
        }
    }
}

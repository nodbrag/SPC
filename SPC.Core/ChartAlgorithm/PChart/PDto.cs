using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.PChart
{
    public class PDto
    {
        /// <summary>
        /// 不良上线控制数据
        /// </summary>
        public List<double> UCL { get; set; }
        /// <summary>
        /// 不良下线控制数据
        /// </summary>
        public List<double> LCL { get; set; }

        /// <summary>
        /// 不良率中止控制数据
        /// </summary>
        public double badCL { get; set; }
        /// <summary>
        /// 良品均值
        /// </summary>
        public double okCL { get; set; }

        /// <summary>
        /// 不良率
        /// </summary>
        public List<double> badRate { get; set; }

        /// <summary>
        /// 合格率
        /// </summary>
        public List<double> okRate { get; set; }

        /// <summary>
        /// X 值
        /// </summary>
        public List<string> xAxisValue { get; set; }

        public PDto()
        {
            UCL = new List<double>();
            LCL = new List<double>();
            badRate = new List<double>();
            okRate = new List<double>();
            xAxisValue = new List<string>();
            badCL = 0;
            okCL=0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.RunningChart
{
    public class RunningChartDto
    {
        /// <summary>
        /// 运行图数据值
        /// </summary>
        public Dictionary<int, List<double>> runningDatas { get; set; }
        /// <summary>
        /// 运行图中线值
        /// </summary>
        public double RunningCL { get; set; }

        public RunningChartDto()
        {
            runningDatas = new Dictionary<int, List<double>>();
        }
    }
}

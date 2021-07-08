using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm.PChart
{
    public class PData
    {
        /// <summary>
        /// 总量
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        ///不合格量
        /// </summary>
        public int errorCount { get; set; }

        /// <summary>
        /// 批次号或时间
        /// </summary>
        public string xAxisValue { get; set; }

        public PData() { }
        public PData(int totalCount, int errorCount,string xAxisValue)
        {

            this.totalCount = totalCount;
            this.errorCount = errorCount;
            this.xAxisValue = xAxisValue;
        }
    }
}

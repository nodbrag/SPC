using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPC.Core.ChartAlgorithm.RunningChart
{
    /// <summary>
    /// 运行图
    /// </summary>
    public class RunningChart
    {
        /// <summary>
        /// 获取运行图
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static RunningChartDto getRunningChart(params List<double>[] datas)
        {
            if (datas.Length <= 0)
                return new RunningChartDto();

            Dictionary<int, List<double>> rows = new Dictionary<int, List<double>>();
            List<double> meanVlues = new List<double>();
            for (int i = 0; i < datas[0].Count; i++)
            {
                List<double> temp = new List<double>();
                foreach (List<double> x in datas) {
                    temp.Add(x[i]);
                }
                rows.Add(i + 1, temp);
                meanVlues.Add(Math.Round(temp.Average(), 5));
            }
           double meanValue=AlgorithmHelper.getMedian(meanVlues);
            RunningChartDto runningChartDto = new RunningChartDto();
            runningChartDto.RunningCL = meanValue;
            runningChartDto.runningDatas = rows;

            return runningChartDto;
        }
    }
}

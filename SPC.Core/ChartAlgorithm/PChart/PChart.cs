using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPC.Core.ChartAlgorithm.PChart
{
    /// <summary>
    /// 不合格率控制图
    /// </summary>
    public class PChart
    {
        /// <summary>
        /// 根据样本数，获取不合格良率图
        /// </summary>
        /// <param name="samples"></param>
        /// <returns></returns>
        public static PDto getPChart(List<PData> samples)
        {
            //均值  p=不良品和/总数和
            double P = (double) samples.Sum(c => c.errorCount) / samples.Sum(c => c.totalCount);
            double okp= (double)samples.Sum(c =>(c.totalCount-c.errorCount)) / samples.Sum(c => c.totalCount);
            List<double> UCL = new List<double>();
            List<double> LCL = new List<double>();
            List<double> badRate = new List<double>();
            List<double> okRate = new List<double>();
            foreach (PData data in samples)
            {
                var num = (3 * Math.Sqrt((1 - P) * P * 1 / data.totalCount));
                UCL.Add(Math.Round(P + num,3));
                LCL.Add(Math.Round(P - num,3));
                badRate.Add(Math.Round((double)data.errorCount / data.totalCount,3));
                okRate.Add(Math.Round((double)(data.totalCount - data.errorCount) / data.totalCount,3));
            }

            PDto pDto = new PDto();
            pDto.LCL = LCL;
            pDto.UCL = UCL;
            pDto.badCL = P;
            pDto.badRate = badRate;
            pDto.okRate = okRate;
            pDto.okCL = okp;
            pDto.xAxisValue = samples.Select(c => c.xAxisValue).ToList();
            return pDto;
        }

    }
}

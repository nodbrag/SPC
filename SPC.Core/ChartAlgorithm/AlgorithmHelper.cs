using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPC.Core.ChartAlgorithm
{
    /// <summary>
    /// 公用基本算法
    /// </summary>
    public class AlgorithmHelper
    {
        /// <summary>
        /// 取平均数 中位数 偶数取中间两个值之和/2 奇数 去中间数值
        /// </summary>
        /// <param name="meanVlues">平均值列表</param>
        public static double getMedian(List<double> meanVlues) {

            meanVlues.Sort();
            double meanval = 0;
            //偶数
            if (meanVlues.Count % 2 == 0)
            {
                meanval = (meanVlues[meanVlues.Count / 2 - 1] + meanVlues[meanVlues.Count / 2]) / 2;
            }
            else
            {
                meanval = meanVlues[meanVlues.Count / 2 - 1];
            }
            return meanval;
        }
        /// <summary>
        /// 获取标准方差
        /// </summary>
        /// <param name="datas">数据</param>
        /// <param name="P">均值</param>
        /// <returns></returns>
        public static double getSigma(List<double> datas,double P) {

            double Sigma = Math.Sqrt(datas.Select(c => new { t = Math.Pow(c - P, 2) }).Sum(c => c.t) / (datas.Count - 1));
            return Sigma;
        }
        /// <summary>
        /// 获取最小测定单位
        /// </summary>
        /// <param name="floatNum">样本数的小数位数</param>
        /// <returns></returns>
        public static double getMinMeaUnit(int floatNum)
        {
            if (floatNum == 0)
            {
                return 1;
            }
            else if (floatNum == 1)
            {
                return 0.1;
            }
            else if (floatNum == 2)
            {
                return 0.01;

            }
            else if (floatNum == 3)
            {
                return 0.001;

            }
            else if (floatNum == 4)
            {
                return 0.0001;

            }
            else
            {
                return 1;
            }
        }


    }
}

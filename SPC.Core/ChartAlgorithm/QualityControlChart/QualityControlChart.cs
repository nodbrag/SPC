using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SPC.Core.ChartAlgorithm.Histogram;

namespace SPC.Core.ChartAlgorithm.QualityControlChart
{
    /// <summary>
    /// 质量控制图
    /// </summary>
    public class QualityControlChart
    {
        /// <summary>
        /// 质量控制系数 A2  暂时支持到15子组
        /// </summary>
        private static List<double> A2Dic = new List<double>
        {1.8880,1.023, 0.729, 0.577, 0.483, 0.419, 0.373 ,0.337,0.308,0.285, 0.266, 0.249, 0.235, 0.223 };
        private static Dictionary<int, double> A2 = new Dictionary<int, double>();
        /// <summary>
        /// 质量控制系数 D3  暂时支持到15子组
        /// </summary>
        private static List<double> D3Dic = new List<double> { 0, 0, 0, 0, 0, 0.076, 0.136, 0.184, 0.223, 0.256, 0.283, 0.307, 0.328, 0.347 }
        ;
        private static Dictionary<int, double> D3 = new Dictionary<int, double>();
        /// <summary>
        /// 质量控制系数 D4  暂时支持到15子组
        /// </summary>
        private static List<double> D4Dic = new List<double> { 3.267, 2.571, 2.282, 2.114, 2.004, 1.924, 1.864, 1.816, 1.777, 1.744, 1.717, 1.693, 1.672, 1.653 };
        private static Dictionary<int, double> D4 = new Dictionary<int, double>();

        
        public static void initA2D3D4()
        {
            for (int i = 2; i < 16; i++)
            {
                if (!A2.ContainsKey(i))
                {
                    A2.Add(i, A2Dic[i - 2]);
                    D3.Add(i, D3Dic[i - 2]);
                    D4.Add(i, D4Dic[i - 2]);
                }
            }
        }

        public static  QualityControlDto GetQualityControlChart(int groupNum, double LSL, double USL, int IntervalNum,int floatNum, params List<double>[] samples)
        {

            if (samples.Length <= 0)
                return new QualityControlDto();
            //初始化系数
            initA2D3D4();

            List<QualityControlParmsDto> qualityControlCalDtos = new List<QualityControlParmsDto>();
            QualityControlDto qualityControlDto = new QualityControlDto();
            Dictionary<int, List<double>> rowSamples = new Dictionary<int, List<double>>();
            ///多组样本 进行组合一组算cpk
            List<double> totalSamples = new List<double>();
            foreach (List<double> x in samples)
            {
                totalSamples.AddRange(x);
            }
            for (int i = 0; i < samples[0].Count; i++)
            {
                List<double> temp = new List<double>();
                foreach(List<double> x in samples)
                {
                    temp.Add(x[i]);
                }
                
                rowSamples.Add(i + 1, temp);
                QualityControlParmsDto  qualityControlParms = new QualityControlParmsDto();
                qualityControlParms.MaxValue = temp.Max();
                qualityControlParms.MinValue = temp.Min();
                qualityControlParms.MeanValue = Math.Round(temp.Average(), 5);
                qualityControlParms.RangeValue = Math.Round(qualityControlParms.MaxValue - qualityControlParms.MinValue, 5);
                qualityControlParms.StandardDeviationValue = AlgorithmHelper.getSigma(temp, qualityControlParms.MeanValue);
                qualityControlCalDtos.Add(qualityControlParms);
            }

            qualityControlDto.MeanCL = qualityControlCalDtos.Select(c => c.MeanValue).ToList().Average();
            qualityControlDto.RangeCL = Math.Round(qualityControlCalDtos.Select(c => c.RangeValue).ToList().Average(), 5);
            qualityControlDto.MeanUCL = Math.Round(qualityControlDto.MeanCL + A2[groupNum] * qualityControlDto.RangeCL, 5);
            qualityControlDto.MeanLCL = Math.Round(qualityControlDto.MeanCL - A2[groupNum] * qualityControlDto.RangeCL, 5);
            qualityControlDto.RangeUCL = D4[groupNum] * qualityControlDto.RangeCL;
            qualityControlDto.RangeLCL = D3[groupNum] * qualityControlDto.RangeCL;
            qualityControlDto.MeanValues = qualityControlCalDtos.Select(c => c.MeanValue).ToList();
            qualityControlDto.RangeValues = qualityControlCalDtos.Select(c => c.RangeValue).ToList();
            qualityControlDto.SampleUCL = Math.Round(qualityControlCalDtos.Select(c => c.MaxValue).Max(), 5);
            qualityControlDto.SampleLCL = Math.Round(qualityControlCalDtos.Select(c => c.MinValue).Min(), 5);
            List<double> meansort = qualityControlCalDtos.Select(c => c.MeanValue).ToList();
            double meanval = AlgorithmHelper.getMedian(meansort);
            qualityControlDto.SampleCL = meanval;
            qualityControlDto.SampleValues = rowSamples;
            if(IntervalNum>0)
            qualityControlDto.histogram = Histogram.Histogram.GetHistogram(totalSamples,"", USL, LSL, IntervalNum, floatNum);

            return qualityControlDto;

        }
        
    }
}

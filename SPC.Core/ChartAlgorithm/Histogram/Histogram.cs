using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SPC.Core.ChartAlgorithm;

namespace SPC.Core.ChartAlgorithm.Histogram
{
    /// <summary>
    /// 直方图
    /// </summary>
    public class Histogram
    {
        /// <summary>
        /// 获取直方图
        /// </summary>
        /// <param name="samples">样本数据</param>
        /// <param name="USL">最大</param>
        /// <param name="LSL">最小</param>
        /// <param name="IntervalNum">区间数量</param>
        /// <param name="floatNum">样本数的小数位数</param>
        /// <returns></returns>
        public static HistogramDto GetHistogram(List<double> samples,string ParameterName, double USL,double LSL,int IntervalNum, int floatNum)
        {
            double minvalue = samples.Min();
            double maxvalue = samples.Max();
            double meanvalue = Math.Round(samples.Average(), 5);
            //最小测定单位
            double minMeaUnit = AlgorithmHelper.getMinMeaUnit(floatNum);
            //组距
            double groupWidth = Math.Round((maxvalue - minvalue + minMeaUnit) / IntervalNum, 9);

            //key 组 value 最小边界和最大边界
            Dictionary<double, HistogramParamsDto> GroupULDic = new Dictionary<double, HistogramParamsDto>();
            for (int i = 0; i < IntervalNum; i++)
            {
                HistogramParamsDto histogramParamsDto = new HistogramParamsDto();
                double LValue, UValue;
                if (i == 0)
                {
                    LValue = minvalue - (minMeaUnit / 2);
                }
                else
                {
                    LValue = GroupULDic[i - 1].UValue;
                }
                UValue = LValue + groupWidth;
                histogramParamsDto.LValue = Math.Round(LValue, floatNum+1);
                histogramParamsDto.UValue = Math.Round(UValue, floatNum+1);
                histogramParamsDto.CValue = Math.Round((UValue + LValue) / 2, floatNum+1);
                if (i == IntervalNum - 1)
                {
                    List<double> vs = samples.Where(c => c >= histogramParamsDto.LValue && c <= histogramParamsDto.UValue).ToList();
                    histogramParamsDto.Number = vs.Count();
                }
                else
                {
                    List<double> vs = samples.Where(c => c >= histogramParamsDto.LValue && c < histogramParamsDto.UValue).ToList();
                    histogramParamsDto.Number = vs.Count();
                }
                GroupULDic.Add(i, histogramParamsDto);
            }
            
            HistogramDto histogramDto = new HistogramDto();
            histogramDto.MaxValue = USL;
            histogramDto.MinValue = LSL;
            histogramDto.XValue = GroupULDic.Select(c => c.Value.CValue).ToList();
            histogramDto.YValue = GroupULDic.Select(c => c.Value.Number).ToList();
            histogramDto.cpk = CPK.getCPK(samples, LSL, USL);
            histogramDto.ParameterName = ParameterName;
            return histogramDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.ChartAlgorithm.RunningChart;
using SPC.Core.ChartAlgorithm;
using SPC.Core.ChartAlgorithm.Histogram;
using SPC.Core.ChartAlgorithm.QualityControlChart;
using SPC.Core.ChartAlgorithm.PChart;
using SPC.Core.ChartAlgorithm.PlatoChart;


namespace SPC.IService
{
    public interface ISpcAnalyseService
    {

        SpcAnalyseDtos.FourPlistDto getFourPlistDto(SpcAnalyseDtos.SpcAnalyseFilter filter);
        /// <summary>
        /// 获取不合格控制数据
        /// </summary>
        /// <returns></returns>
        PDto GetPChartData(SpcAnalyseDtos.SpcAnalyseFilter filter);
        /// <summary>
        /// 获取柏拉图数据
        /// </summary>
        /// <returns></returns>
        PlatoDto GetPlatoChartData(SpcAnalyseDtos.SpcAnalyseFilter filter);
        /// <summary>
        /// Plist
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<SpcAnalyseDtos.PListDto> GetPlistData(SpcAnalyseDtos.SpcAnalyseFilter filter);
        /// <summary>
        /// Plist
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<SpcAnalyseDtos.PListDto> GetPlistData(string batchNo);
        /// <summary>
        /// 获取cpk数据
        /// </summary>
        /// <returns></returns>
        CPKDto GetCPKData();
        /// <summary>
        /// 获取运行图数据列表
        /// </summary>
        /// <returns></returns>
        RunningChartDto GetRunningChartData();
        /// <summary>
        /// 获取质量控制报表数据
        /// </summary>
        /// <returns></returns>
        QualityControlDto GetQualityControlData();
        /// <summary>
        /// 获取直方图报表数据
        /// </summary>
        /// <returns></returns>
        List<HistogramDto> GetHistogramData(string BatchNo);
        
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using SPC.Core.Extensions;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SPC.Core.Filter;

namespace SPC.Api.Controllers
{
    /// <summary>
    /// Spc 分析接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "SPCAnalysis")]
    public class SpcAnalyseController
    {
        private readonly ISpcAnalyseService _spcAnalyseService;
        private readonly ILogger _logger;
        public SpcAnalyseController(ISpcAnalyseService spcAnalyseService, ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
            _spcAnalyseService = spcAnalyseService;
        }
        /// <summary>
        ///     获取不良品控制分析数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetBadControlData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetPChartData(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取柏拉图+列表+不良品控制图+合格率图
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetFourPData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            try
            {    
                return new OkOpResult(_spcAnalyseService.getFourPlistDto(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取柏拉图+列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetTowPData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            try
            {

                SpcAnalyseDtos.TwoPlistDto tp = new SpcAnalyseDtos.TwoPlistDto();
                tp.pListDtos = _spcAnalyseService.GetPlistData(filter);
                tp.platoDto = _spcAnalyseService.GetPlatoChartData(filter);
                return new OkOpResult(tp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取不良数据列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetPlistData(SpcAnalyseDtos.SpcAnalyseFilter filter) {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetPlistData(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取不良数据列表 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult GetPlistDataByBatchNo(string batchNo)
        {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetPlistData(batchNo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取不拉图报表数据
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetPlatoChartData(SpcAnalyseDtos.SpcAnalyseFilter filter)
        {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetPlatoChartData(filter));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取Cpk数据分析
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetCPKData() {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetCPKData());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }
        /// <summary>
        /// 获取运行图数据案例
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetRunningChartData()
        {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetRunningChartData());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }
        /// <summary>
        /// 获取质量控制数据案例
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecResult GetQualityControlData()
        {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetQualityControlData());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取Cpk 和直方图数据分析
        /// </summary>
        /// <param name="BatchNo">批次号</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult GetHistogramData(string BatchNo) {
            try
            {
                return new OkOpResult(_spcAnalyseService.GetHistogramData(BatchNo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }

        }

    }
}

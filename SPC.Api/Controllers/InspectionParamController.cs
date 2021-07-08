/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： InspectionParamController                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using SPC.Core.Extensions;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;
using Microsoft.Extensions.Logging;
using SPC.Core.Filter;

namespace SPC.Api.Controllers
{
    /// <summary>
    /// 产品检测参数管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class InspectionParamController : ControllerBase
    {
        private readonly  IInspectionParamService _InspectionParamService;
        private readonly ILogger _logger;
        public InspectionParamController(IInspectionParamService InspectionParamService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _InspectionParamService = InspectionParamService;
        }
        /// <summary>
        ///     创建产品检测参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateInspectionParam([FromBody]InspectionParamDtos.InspectionParamDto model)
        {
            try
            {
                _InspectionParamService.CreateInspectionParam(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改产品检测参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateInspectionParam([FromBody]InspectionParamDtos.InspectionParamDto model)
        {
            try
            {
                _InspectionParamService.UpdateInspectionParam(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除产品检测参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteInspectionParam(int id)
        {
            try
            {
                _InspectionParamService.DeleteInspectionParam(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取产品检测参数信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<InspectionParamDtos.InspectionParamDto> GetInspectionParamByID(int id)
        {
            try
            {
                InspectionParamDtos.InspectionParamDto InspectionParamDto= _InspectionParamService.GetInspectionParamByID(id);
                return new OkOpResult<InspectionParamDtos.InspectionParamDto>(InspectionParamDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<InspectionParamDtos.InspectionParamDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有产品检测参数列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<InspectionParamDtos.InspectionParamDto> GetInspectionParamList()
        {
            try
            {
                List<InspectionParamDtos.InspectionParamDto> InspectionParamDtos = _InspectionParamService.GetInspectionParamList();
                return new OkOpPageResult<InspectionParamDtos.InspectionParamDto>(InspectionParamDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<InspectionParamDtos.InspectionParamDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取产品检测参数分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<InspectionParamDtos.InspectionParamDto> GetInspectionParamListForPagination([FromBody]FiterConditionBase<InspectionParamDtos.InspectionParamFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetInspectionParamList();
                Tuple<List<InspectionParamDtos.InspectionParamDto>, int> list = _InspectionParamService.GetInspectionParamListForPagination(fiterCondition);
                return new OkOpPageResult<InspectionParamDtos.InspectionParamDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<InspectionParamDtos.InspectionParamDto>(ex.GetInnerException());
            }
           
        }

    }
}

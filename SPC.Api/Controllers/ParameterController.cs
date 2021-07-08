/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： ParameterController                                    
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
    /// 参数管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class ParameterController : ControllerBase
    {
        private readonly  IParameterService _ParameterService;
        private readonly ILogger _logger;
        public ParameterController(IParameterService ParameterService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _ParameterService = ParameterService;
        }
        /// <summary>
        ///     创建参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateParameter([FromBody]ParameterDtos.ParameterDto model)
        {
            try
            {
                _ParameterService.CreateParameter(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateParameter([FromBody]ParameterDtos.ParameterDto model)
        {
            try
            {
                _ParameterService.UpdateParameter(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteParameter(int id)
        {
            try
            {
                _ParameterService.DeleteParameter(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取参数信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<ParameterDtos.ParameterDto> GetParameterByID(int id)
        {
            try
            {
                ParameterDtos.ParameterDto ParameterDto= _ParameterService.GetParameterByID(id);
                return new OkOpResult<ParameterDtos.ParameterDto>(ParameterDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<ParameterDtos.ParameterDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有参数列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<ParameterDtos.ParameterDto> GetParameterList()
        {
            try
            {
                List<ParameterDtos.ParameterDto> ParameterDtos = _ParameterService.GetParameterList();
                return new OkOpPageResult<ParameterDtos.ParameterDto>(ParameterDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<ParameterDtos.ParameterDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取参数分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<ParameterDtos.ParameterDto> GetParameterListForPagination([FromBody]FiterConditionBase<ParameterDtos.ParameterFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetParameterList();
                Tuple<List<ParameterDtos.ParameterDto>, int> list = _ParameterService.GetParameterListForPagination(fiterCondition);
                return new OkOpPageResult<ParameterDtos.ParameterDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<ParameterDtos.ParameterDto>(ex.GetInnerException());
            }
           
        }

    }
}

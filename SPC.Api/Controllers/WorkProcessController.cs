/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： WorkProcessController                                    
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
    /// 工序管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class WorkProcessController : ControllerBase
    {
        private readonly  IWorkProcessService _WorkProcessService;
        private readonly ILogger _logger;
        public WorkProcessController(IWorkProcessService WorkProcessService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _WorkProcessService = WorkProcessService;
        }
        /// <summary>
        ///     创建工序
        /// </summary>
        /// <param name="model">工序信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateWorkProcess([FromBody]WorkProcessDtos.WorkProcessDto model)
        {
            try
            {
                _WorkProcessService.CreateWorkProcess(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改工序
        /// </summary>
        /// <param name="model">工序信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateWorkProcess([FromBody]WorkProcessDtos.WorkProcessDto model)
        {
            try
            {
                _WorkProcessService.UpdateWorkProcess(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除工序
        /// </summary>
        /// <param name="id">工序ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteWorkProcess(int id)
        {
            try
            {
                _WorkProcessService.DeleteWorkProcess(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取工序信息
        /// </summary>
        /// <param name="id">工序ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<WorkProcessDtos.WorkProcessDto> GetWorkProcessByID(int id)
        {
            try
            {
                WorkProcessDtos.WorkProcessDto WorkProcessDto= _WorkProcessService.GetWorkProcessByID(id);
                return new OkOpResult<WorkProcessDtos.WorkProcessDto>(WorkProcessDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<WorkProcessDtos.WorkProcessDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有工序列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<WorkProcessDtos.WorkProcessDto> GetWorkProcessList()
        {
            try
            {
                List<WorkProcessDtos.WorkProcessDto> WorkProcessDtos = _WorkProcessService.GetWorkProcessList();
                return new OkOpPageResult<WorkProcessDtos.WorkProcessDto>(WorkProcessDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<WorkProcessDtos.WorkProcessDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取工序分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<WorkProcessDtos.WorkProcessDto> GetWorkProcessListForPagination([FromBody]FiterConditionBase<WorkProcessDtos.WorkProcessFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetWorkProcessList();
                Tuple<List<WorkProcessDtos.WorkProcessDto>, int> list = _WorkProcessService.GetWorkProcessListForPagination(fiterCondition);
                return new OkOpPageResult<WorkProcessDtos.WorkProcessDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<WorkProcessDtos.WorkProcessDto>(ex.GetInnerException());
            }
           
        }

    }
}

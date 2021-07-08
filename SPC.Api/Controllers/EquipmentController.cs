/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： EquipmentController                                    
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
    /// 设备管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class EquipmentController : ControllerBase
    {
        private readonly  IEquipmentService _EquipmentService;
        private readonly ILogger _logger;
        public EquipmentController(IEquipmentService EquipmentService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _EquipmentService = EquipmentService;
        }
        /// <summary>
        ///     创建设备
        /// </summary>
        /// <param name="model">设备信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateEquipment([FromBody]EquipmentDtos.EquipmentDto model)
        {
            try
            {
                _EquipmentService.CreateEquipment(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改设备
        /// </summary>
        /// <param name="model">设备信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateEquipment([FromBody]EquipmentDtos.EquipmentDto model)
        {
            try
            {
                _EquipmentService.UpdateEquipment(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="id">设备ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteEquipment(int id)
        {
            try
            {
                _EquipmentService.DeleteEquipment(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取设备信息
        /// </summary>
        /// <param name="id">设备ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<EquipmentDtos.EquipmentDto> GetEquipmentByID(int id)
        {
            try
            {
                EquipmentDtos.EquipmentDto EquipmentDto= _EquipmentService.GetEquipmentByID(id);
                return new OkOpResult<EquipmentDtos.EquipmentDto>(EquipmentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<EquipmentDtos.EquipmentDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有设备列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<EquipmentDtos.EquipmentDto> GetEquipmentList()
        {
            try
            {
                List<EquipmentDtos.EquipmentDto> EquipmentDtos = _EquipmentService.GetEquipmentList();
                return new OkOpPageResult<EquipmentDtos.EquipmentDto>(EquipmentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<EquipmentDtos.EquipmentDto>(ex.GetInnerException());
            }
        }    
        /// <summary>
        /// 通过过滤条件获取设备分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<EquipmentDtos.EquipmentDto> GetEquipmentListForPagination([FromBody]FiterConditionBase<EquipmentDtos.EquipmentFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetEquipmentList();
                Tuple<List<EquipmentDtos.EquipmentDto>, int> list = _EquipmentService.GetEquipmentListForPagination(fiterCondition);
                return new OkOpPageResult<EquipmentDtos.EquipmentDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<EquipmentDtos.EquipmentDto>(ex.GetInnerException());
            }
           
        }

    }
}

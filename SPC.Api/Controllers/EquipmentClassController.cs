/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： EquipmentClassController                                    
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
    /// 设备分类管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class EquipmentClassController : ControllerBase
    {
        private readonly  IEquipmentClassService _EquipmentClassService;
        private readonly ILogger _logger;
        public EquipmentClassController(IEquipmentClassService EquipmentClassService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _EquipmentClassService = EquipmentClassService;
        }
        /// <summary>
        ///     创建设备分类
        /// </summary>
        /// <param name="model">设备分类信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateEquipmentClass([FromBody]EquipmentClassDtos.EquipmentClassDto model)
        {
            try
            {
                _EquipmentClassService.CreateEquipmentClass(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改设备分类
        /// </summary>
        /// <param name="model">设备分类信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateEquipmentClass([FromBody]EquipmentClassDtos.EquipmentClassDto model)
        {
            try
            {
                _EquipmentClassService.UpdateEquipmentClass(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除设备分类
        /// </summary>
        /// <param name="id">设备分类ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteEquipmentClass(int id)
        {
            try
            {
                _EquipmentClassService.DeleteEquipmentClass(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取设备分类信息
        /// </summary>
        /// <param name="id">设备分类ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<EquipmentClassDtos.EquipmentClassDto> GetEquipmentClassByID(int id)
        {
            try
            {
                EquipmentClassDtos.EquipmentClassDto EquipmentClassDto= _EquipmentClassService.GetEquipmentClassByID(id);
                return new OkOpResult<EquipmentClassDtos.EquipmentClassDto>(EquipmentClassDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<EquipmentClassDtos.EquipmentClassDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有设备分类列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<EquipmentClassDtos.EquipmentClassDto> GetEquipmentClassList()
        {
            try
            {
                List<EquipmentClassDtos.EquipmentClassDto> EquipmentClassDtos = _EquipmentClassService.GetEquipmentClassList();
                return new OkOpPageResult<EquipmentClassDtos.EquipmentClassDto>(EquipmentClassDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<EquipmentClassDtos.EquipmentClassDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取设备分类分页数据
        /// </summary>
        /// <param name="fiterCondition">过滤条件</param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<EquipmentClassDtos.EquipmentClassDto> GetEquipmentClassListForPagination([FromBody]FiterConditionBase<EquipmentClassDtos.EquipmentClassFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetEquipmentClassList();
                Tuple<List<EquipmentClassDtos.EquipmentClassDto>, int> list = _EquipmentClassService.GetEquipmentClassListForPagination(fiterCondition);
                return new OkOpPageResult<EquipmentClassDtos.EquipmentClassDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<EquipmentClassDtos.EquipmentClassDto>(ex.GetInnerException());
            }
           
        }

    }
}

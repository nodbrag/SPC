/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： DefectItemController                                    
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
    /// 缺陷项管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "BasicInformation")]
    public class DefectItemController : ControllerBase
    {
        private readonly  IDefectItemService _DefectItemService;
        private readonly ILogger _logger;
        public DefectItemController(IDefectItemService DefectItemService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _DefectItemService = DefectItemService;
        }
        /// <summary>
        ///     创建缺陷项
        /// </summary>
        /// <param name="model">缺陷项信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateDefectItem([FromBody]DefectItemDtos.DefectItemDto model)
        {
            try
            {
                _DefectItemService.CreateDefectItem(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改缺陷项
        /// </summary>
        /// <param name="model">缺陷信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateDefectItem([FromBody]DefectItemDtos.DefectItemDto model)
        {
            try
            {
                _DefectItemService.UpdateDefectItem(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除缺陷项
        /// </summary>
        /// <param name="id">缺陷项ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteDefectItem(int id)
        {
            try
            {
                _DefectItemService.DeleteDefectItem(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取缺陷项信息
        /// </summary>
        /// <param name="id">缺陷项ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<DefectItemDtos.DefectItemDto> GetDefectItemByID(int id)
        {
            try
            {
                DefectItemDtos.DefectItemDto DefectItemDto= _DefectItemService.GetDefectItemByID(id);
                return new OkOpResult<DefectItemDtos.DefectItemDto>(DefectItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<DefectItemDtos.DefectItemDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有缺陷项列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<DefectItemDtos.DefectItemDto> GetDefectItemList()
        {
            try
            {
                List<DefectItemDtos.DefectItemDto> DefectItemDtos = _DefectItemService.GetDefectItemList();
                return new OkOpPageResult<DefectItemDtos.DefectItemDto>(DefectItemDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<DefectItemDtos.DefectItemDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取缺陷项分页数据
        /// </summary>
        /// <param name="fiterCondition">过滤条件</param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<DefectItemDtos.DefectItemDto> GetDefectItemListForPagination([FromBody]FiterConditionBase<DefectItemDtos.DefectItemFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetDefectItemList();
                Tuple<List<DefectItemDtos.DefectItemDto>, int> list = _DefectItemService.GetDefectItemListForPagination(fiterCondition);
                return new OkOpPageResult<DefectItemDtos.DefectItemDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<DefectItemDtos.DefectItemDto>(ex.GetInnerException());
            }
           
        }

    }
}

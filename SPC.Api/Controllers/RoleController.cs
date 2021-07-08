/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Api.Controllers                                  
*│　类    名： RoleController                                    
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
    /// 角色管理接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "SystemSetting")]
    public class RoleController : SpcControllerBase
    {
        private readonly  IRoleService _RoleService;
        private readonly ILogger _logger;
        public RoleController(IRoleService RoleService, ILogger<ExceptionFilter> logger) {
            _logger = logger;
            _RoleService = RoleService;
        }
        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="model">新增角色信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult CreateRole([FromBody]RoleDtos.RoleDto model)
        {
            try
            {
                _RoleService.CreateRole(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        ///     修改角色
        /// </summary>
        /// <param name="model">编辑角色信息</param>
        /// <returns></returns>
        [HttpPost]
        public IExecResult UpdateRole([FromBody]RoleDtos.RoleDto model)
        {
            try
            {
                _RoleService.UpdateRole(model);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult DeleteRole(int id)
        {
            try
            {
                _RoleService.DeleteRole(id);
                return new OkOpResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 通过编号获取角色信息
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        [HttpGet]
        public IExecResult<RoleDtos.RoleDto> GetRoleByID(int id)
        {
            try
            {
                RoleDtos.RoleDto RoleDto= _RoleService.GetRoleByID(id);
                return new OkOpResult<RoleDtos.RoleDto>(RoleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpResult<RoleDtos.RoleDto>(ex.GetInnerException());
            }
        }
        /// <summary>
        /// 获取所有角色列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<RoleDtos.RoleDto> GetRoleList()
        {
           
            try
            {
                List<RoleDtos.RoleDto> RoleDtos = _RoleService.GetRoleList();
                return new OkOpPageResult<RoleDtos.RoleDto>(RoleDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<RoleDtos.RoleDto>(ex.GetInnerException());
            }
        }
        
        /// <summary>
        /// 通过过滤条件获取角色分页数据
        /// </summary>
        /// <param name="fiterCondition">搜索过滤条件</param>
        /// <returns></returns>
        [HttpPost]
        public IExecPageResult<RoleDtos.RoleDto> GetRoleListForPagination([FromBody]FiterConditionBase<RoleDtos.RoleFilterDto> fiterCondition)
        {
            try
            {
                if (fiterCondition == null)
                    return GetRoleList();
                Tuple<List<RoleDtos.RoleDto>, int> list = _RoleService.GetRoleListForPagination(fiterCondition);
                return new OkOpPageResult<RoleDtos.RoleDto>(list.Item1, list.Item2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetInnerException());
                return new BadOpPageResult<RoleDtos.RoleDto>(ex.GetInnerException());
            }
           
        }

    }
}

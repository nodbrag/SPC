/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 17:38:10                           
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.IService                                   
*│　接口名称： IRoleService                                      
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.Models.DtoModel;
using SPC.Core.Dtos;

namespace SPC.IService
{
    public interface IRoleService
    {
        /// <summary>
        /// 创建Role
        /// </summary>
        /// <param name="model"></param>
        void CreateRole(RoleDtos.RoleDto model);
        /// <summary>
        /// 修改Role
        /// </summary>
        /// <param name="model"></param>
        void UpdateRole(RoleDtos.RoleDto model);
        /// <summary>
        /// 删除Role根据ID
        /// </summary>
        /// <param name="id"></param>
        void DeleteRole(int id);
        /// <summary>
        /// 通过编号获取Role信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleDtos.RoleDto GetRoleByID(int id);
        /// <summary>
        /// 获取所有Role 列表信息
        /// </summary>
        /// <returns></returns>
        List<RoleDtos.RoleDto> GetRoleList();
        /// <summary>
        /// 通过过滤条件获取Role分页数据
        /// </summary>
        /// <param name="fiterCondition"></param>
        /// <returns></returns>
        Tuple<List<RoleDtos.RoleDto>, int> GetRoleListForPagination(FiterConditionBase<RoleDtos.RoleFilterDto> fiterCondition);

    }
}


/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： RoleService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using SPC.IService;
using SPC.Models.DtoModel;
using SPC.Models.DataModel;
using SPC.Core.Dtos;
using SPC.Core.Extensions;
using System.Reflection;
using System.Linq;
using SPC.Core.Attribute;
using SPC.Core.Utility;
using SPC.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace SPC.Service
{
    public class RoleService : IRoleService
    {
        private readonly SPCContext _context;

        public RoleService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateRole(RoleDtos.RoleDto model)
        {
            _context.Role.Add(model.MapTo<Role>());
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            Role role= _context.Role.Find(id);
            if (role == null)
                throw new Exception("编号为" + id + "的角色不存在!");
            _context.Remove(role);
            _context.SaveChanges();
        }

        public RoleDtos.RoleDto GetRoleByID(int id)
        {
            Role role = _context.Role.Find(id);
            if (role == null)
                throw new Exception("编号为" + id + "的角色不存在!");
            return role.MapTo<RoleDtos.RoleDto>();
        }

        public List<RoleDtos.RoleDto> GetRoleList()
        {
            return _context.Role.Select<RoleDtos.RoleDto>().AsNoTracking().ToList();
        }

        public Tuple<List<RoleDtos.RoleDto>, int> GetRoleListForPagination(FiterConditionBase<RoleDtos.RoleFilterDto> fiterCondition)
        {
            var query = _context.Role.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<Role>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<Role> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }

            return query.Select<RoleDtos.RoleDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateRole(RoleDtos.RoleDto model)
        {
             _context.Role.Update(model.MapTo<Role>());
            _context.SaveChanges();
        }
    }
}

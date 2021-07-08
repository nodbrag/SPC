/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： ParameterService                                    
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
    public class ParameterService : IParameterService
    {
        private readonly SPCContext _context;

        public ParameterService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateParameter(ParameterDtos.ParameterDto model)
        {
            _context.Parameter.Add(model.MapTo<Parameter>());
            _context.SaveChanges();
        }

        public void DeleteParameter(int id)
        {
            Parameter entity= _context.Parameter.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Parameter不存在!");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public ParameterDtos.ParameterDto GetParameterByID(int id)
        {
            Parameter entity = _context.Parameter.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的Parameter不存在!");
            return entity.MapTo<ParameterDtos.ParameterDto>();
        }

        public List<ParameterDtos.ParameterDto> GetParameterList()
        {
            return _context.Parameter.Select<ParameterDtos.ParameterDto>().AsNoTracking().ToList();
        }

        public Tuple<List<ParameterDtos.ParameterDto>, int> GetParameterListForPagination(FiterConditionBase<ParameterDtos.ParameterFilterDto> fiterCondition)
        {
            var query = _context.Parameter.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<Parameter>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<Parameter> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }

            return query.Select<ParameterDtos.ParameterDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateParameter(ParameterDtos.ParameterDto model)
        {
             _context.Parameter.Update(model.MapTo<Parameter>());
            _context.SaveChanges();
        }
    }
}

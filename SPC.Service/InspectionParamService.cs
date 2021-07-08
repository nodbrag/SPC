/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： InspectionParamService                                    
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
    public class InspectionParamService : IInspectionParamService
    {
        private readonly SPCContext _context;

        public InspectionParamService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateInspectionParam(InspectionParamDtos.InspectionParamDto model)
        {
            _context.InspectionParam.Add(model.MapTo<InspectionParam>());
            _context.SaveChanges();
        }

        public void DeleteInspectionParam(int id)
        {
            InspectionParam entity= _context.InspectionParam.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的InspectionParam不存在!");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public InspectionParamDtos.InspectionParamDto GetInspectionParamByID(int id)
        {
            InspectionParam entity = _context.InspectionParam.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的InspectionParam不存在!");
            return entity.MapTo<InspectionParamDtos.InspectionParamDto>();
        }

        public List<InspectionParamDtos.InspectionParamDto> GetInspectionParamList()
        {
            return _context.InspectionParam.SelectMap<InspectionParamDtos.InspectionParamDto>().AsNoTracking().ToList();
        }

        public Tuple<List<InspectionParamDtos.InspectionParamDto>, int> GetInspectionParamListForPagination(FiterConditionBase<InspectionParamDtos.InspectionParamFilterDto> fiterCondition)
        {
            var query = _context.InspectionParam.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<InspectionParam>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<InspectionParam> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }

            return query.SelectMap<InspectionParamDtos.InspectionParamDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateInspectionParam(InspectionParamDtos.InspectionParamDto model)
        {
             _context.InspectionParam.Update(model.MapTo<InspectionParam>());
            _context.SaveChanges();
        }
    }
}

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： DefectItemService                                    
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
    public class DefectItemService : IDefectItemService
    {
        private readonly SPCContext _context;

        public DefectItemService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateDefectItem(DefectItemDtos.DefectItemDto model)
        {
            _context.DefectItem.Add(model.MapTo<DefectItem>());
            _context.SaveChanges();
        }

        public void DeleteDefectItem(int id)
        {
            DefectItem entity= _context.DefectItem.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的DefectItem不存在!");
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public DefectItemDtos.DefectItemDto GetDefectItemByID(int id)
        {
            DefectItem entity = _context.DefectItem.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的DefectItem不存在!");
            return entity.MapTo<DefectItemDtos.DefectItemDto>();
        }

        public List<DefectItemDtos.DefectItemDto> GetDefectItemList()
        {
            return _context.DefectItem.Select<DefectItemDtos.DefectItemDto>().AsNoTracking().ToList();
        }

        public Tuple<List<DefectItemDtos.DefectItemDto>, int> GetDefectItemListForPagination(FiterConditionBase<DefectItemDtos.DefectItemFilterDto> fiterCondition)
        {
            var query = _context.DefectItem.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<DefectItem>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<DefectItem> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }
            return query.Select<DefectItemDtos.DefectItemDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateDefectItem(DefectItemDtos.DefectItemDto model)
        {
             _context.DefectItem.Update(model.MapTo<DefectItem>());
            _context.SaveChanges();
        }
    }
}

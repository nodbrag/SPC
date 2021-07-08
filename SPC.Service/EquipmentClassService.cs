/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： EquipmentClassService                                    
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
    public class EquipmentClassService : IEquipmentClassService
    {
       
        private readonly SPCContext _context;

        public EquipmentClassService(SPCContext context)
        {
            this._context = context;
        }
        public void CreateEquipmentClass(EquipmentClassDtos.EquipmentClassDto model)
        {
            _context.EquipmentClass.Add(model.MapTo<EquipmentClass>());
            _context.SaveChanges();
        }

        public void DeleteEquipmentClass(int id)
        {
           
            EquipmentClass equipmentClass = _context.EquipmentClass.Find(id);
            if (equipmentClass == null)
                throw new Exception("编号为" + id + "的设备分类不存在!");
            _context.Remove(equipmentClass);
            _context.SaveChanges();
        }

        public EquipmentClassDtos.EquipmentClassDto GetEquipmentClassByID(int id)
        {
            EquipmentClass equipmentClass = _context.EquipmentClass.Find(id);
            if (equipmentClass == null)
                throw new Exception("编号为" + id + "的设备分类不存在!");
            return equipmentClass.MapTo<EquipmentClassDtos.EquipmentClassDto>();
        }

        public List<EquipmentClassDtos.EquipmentClassDto> GetEquipmentClassList()
        {
            return _context.EquipmentClass.Select<EquipmentClassDtos.EquipmentClassDto>().AsNoTracking().ToList();
        }

        public Tuple<List<EquipmentClassDtos.EquipmentClassDto>, int> GetEquipmentClassListForPagination(FiterConditionBase<EquipmentClassDtos.EquipmentClassFilterDto> fiterCondition)
        {
            var query = _context.EquipmentClass.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<EquipmentClass>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<EquipmentClass> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }
            return query.Select<EquipmentClassDtos.EquipmentClassDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateEquipmentClass(EquipmentClassDtos.EquipmentClassDto model)
        {
            _context.EquipmentClass.Update(model.MapTo<EquipmentClass>());
            _context.SaveChanges();
        }
    }
}

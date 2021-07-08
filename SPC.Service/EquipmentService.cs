/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-11 17:38:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： EquipmentService                                    
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
    public class EquipmentService : IEquipmentService
    {
        private readonly SPCContext _context;

        public EquipmentService(SPCContext context)
        {
            this._context = context;
        }
        
        public void CreateEquipment(EquipmentDtos.EquipmentDto model)
        {
            _context.Equipment.Add(model.MapTo<Equipment>());
            _context.SaveChanges();
        }

        public void DeleteEquipment(int id)
        {
            Equipment equipment = _context.Equipment.Find(id);
            if (equipment == null)
                throw new Exception("编号为" + id + "的设备不存在!");
            _context.Remove(equipment);
            _context.SaveChanges();
        }

        public EquipmentDtos.EquipmentDto GetEquipmentByID(int id)
        {
             Equipment equipment = _context.Equipment.Find(id);
            if (equipment == null)
                throw new Exception("编号为" + id + "的设备不存在!");
            return equipment.MapTo<EquipmentDtos.EquipmentDto>();
        }

        public List<EquipmentDtos.EquipmentDto> GetEquipmentList()
        {
            return _context.Equipment.SelectMap<EquipmentDtos.EquipmentDto>().AsNoTracking().ToList();
        }

        public Tuple<List<EquipmentDtos.EquipmentDto>, int> GetEquipmentListForPagination(FiterConditionBase<EquipmentDtos.EquipmentFilterDto> fiterCondition)
        {
            var query = _context.Equipment.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<Equipment>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<Equipment> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }
            return query.SelectMap<EquipmentDtos.EquipmentDto>().GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateEquipment(EquipmentDtos.EquipmentDto model)
        {
            _context.Equipment.Update(model.MapTo<Equipment>());
            _context.SaveChanges();
        }
    }
}

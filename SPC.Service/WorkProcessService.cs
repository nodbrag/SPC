/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-07-18 09:03:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： SPC.Service                                  
*│　类    名： WorkProcessService                                    
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
    public class WorkProcessService : IWorkProcessService
    {
        private readonly SPCContext _context;

        public WorkProcessService(SPCContext context)
        {
            this._context = context;
        }

        public void CreateWorkProcess(WorkProcessDtos.WorkProcessDto model)
        {
          

            WorkProcess newWorkProcess= model.MapTo<WorkProcess>();
            List<WorkProcessDefect> workProcessDefects = new List<WorkProcessDefect>();
            foreach (int id in model.DefectItemID)
            {
                WorkProcessDefect workProcessDefect = new WorkProcessDefect();
                workProcessDefect.DefectItemId = id;
                workProcessDefect.WorkProcessId = newWorkProcess.WorkProcessId;
                workProcessDefects.Add(workProcessDefect);
            }
            newWorkProcess.WorkProcessDefect = workProcessDefects;
            _context.Add(newWorkProcess);
            _context.SaveChanges();
        }

        public void DeleteWorkProcess(int id)
        {
            WorkProcess entity= _context.WorkProcess.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的WorkProcess不存在!");
            _context.Remove(entity);
            //删除工序缺陷
            List<WorkProcessDefect> workProcessDefects = _context.WorkProcessDefect.Where(c => c.WorkProcessId == id).ToList();
            if (workProcessDefects.Count > 0)
                _context.RemoveRange(workProcessDefects);

            _context.SaveChanges();
        }

        public WorkProcessDtos.WorkProcessDto GetWorkProcessByID(int id)
        {
            WorkProcess entity = _context.WorkProcess.Find(id);
            if (entity == null)
                throw new Exception("编号为" + id + "的WorkProcess不存在!");
            return entity.MapTo<WorkProcessDtos.WorkProcessDto>();
        }

        public List<WorkProcessDtos.WorkProcessDto> GetWorkProcessList()
        {
            return _context.WorkProcess.Select(p => new WorkProcessDtos.WorkProcessDto
            {
                WorkProcessID = p.WorkProcessId, Memo = p.Memo, WorkProcessCode = p.WorkProcessCode, WorkProcessName = p.WorkProcessName,
                DefectItemID = p.WorkProcessDefect.Select(c => c.DefectItemId).ToList(), DefectItemNames = String.Join(",",p.WorkProcessDefect.Join(_context.DefectItem, di => di.DefectItemId, wp => wp.DefectItemId, (di, wp) => new {
                    wp.DefectItemName
                }).Select(c=>c.DefectItemName).ToList())
            }).AsNoTracking().ToList();
        }

        public Tuple<List<WorkProcessDtos.WorkProcessDto>, int> GetWorkProcessListForPagination(FiterConditionBase<WorkProcessDtos.WorkProcessFilterDto> fiterCondition)
        {
            var query = _context.WorkProcess.AsNoTracking();
            List<Filter> Filters = FilterCondition.GetFilters(fiterCondition);
            if (Filters.Count > 0)
                foreach (var item in Filters)
                    query = query.Where(LambdaProvider.GetLambdaByFilter<WorkProcess>(item));

            if (fiterCondition.Sortings != null && fiterCondition.Sortings.Count > 0)
            {
                IOrderedQueryable<WorkProcess> sortquery = query.SortBy(fiterCondition.Sortings);
                if (sortquery != null)
                    query = sortquery;
            }

            return query.Select(p => new WorkProcessDtos.WorkProcessDto
            {
                WorkProcessID = p.WorkProcessId,
                Memo = p.Memo,
                WorkProcessCode = p.WorkProcessCode,
                WorkProcessName = p.WorkProcessName,
                DefectItemID = p.WorkProcessDefect.Select(c => c.DefectItemId).ToList(),
                DefectItemNames = String.Join(",", p.WorkProcessDefect.Join(_context.DefectItem, di => di.DefectItemId, wp => wp.DefectItemId, (di, wp) => new {
                    wp.DefectItemName
                }).Select(c => c.DefectItemName).ToList())
            }).GetAllList(fiterCondition.SkipCount, fiterCondition.MaxResultCount);
        }

        public void UpdateWorkProcess(WorkProcessDtos.WorkProcessDto model)
        {

            WorkProcess workProcess = _context.WorkProcess.Where(c => c.WorkProcessId == model.WorkProcessID).AsNoTracking().FirstOrDefault();
            if (workProcess == null)
                throw new Exception("编号为" + model.WorkProcessID + "的工序不存在!");
           
            WorkProcess newWorkProcess = model.MapTo<WorkProcess>();
            List<WorkProcessDefect> workProcessDefects = new List<WorkProcessDefect>();
            foreach (int id in model.DefectItemID)
            {
                WorkProcessDefect workProcessDefect = new WorkProcessDefect();
                workProcessDefect.DefectItemId = id;
                workProcessDefect.WorkProcessId = newWorkProcess.WorkProcessId;
                workProcessDefects.Add(workProcessDefect);
            }
            newWorkProcess.WorkProcessDefect = workProcessDefects;
            _context.Update(newWorkProcess);
            //删除工序缺陷
            workProcessDefects = _context.WorkProcessDefect.Where(c => c.WorkProcessId == model.WorkProcessID).ToList();
            _context.WorkProcessDefect.RemoveRange(workProcessDefects);
            _context.SaveChanges();
        }
    }
}

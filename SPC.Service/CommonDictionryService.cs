using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Dtos;
using SPC.IService;
using SPC.Models.DataModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SPC.Service
{
    public class CommonDictionryService : ICommonDictionryService
    {
        private readonly SPCContext _context;

        public CommonDictionryService(SPCContext context)
        {
            this._context = context;
           
        }
        public IExecResult GetCommonDictionry()
        {
            var role =  _context.Role.Where(c=>c.RoleName!="超级管理员").Select(p=> new { Id = p.RoleId, Name = p.RoleName });
            var equipmentClass = _context.EquipmentClass.Select(p => new { Id = p.EquipmentClassId, Name = p.EquipmentClassName });
            var defectItem=_context.DefectItem.Select(p=>new { Id = p.DefectItemId, Name = p.DefectItemName });
            var product = _context.Product.Select(p => new { Id = p.ProductId, Name = p.ProductName }).ToList();
            var workprocess = _context.WorkProcess.Select(p => new { Id = p.WorkProcessId, Name = p.WorkProcessName });
            var parameter = _context.Parameter.Select(p => new { Id = p.ParameterId, Name = p.ParameterName });
            var equipment = _context.Equipment.Select(p => new { Id = p.EquipmentId, Name = p.EquipmentName });
            return new OkOpResult(new { Role = role, EquipmentClass=equipmentClass,DefectItem= defectItem,Product= product ,WorkProcess= workprocess,Parameter=parameter ,Equipment=equipment});
        }
    }
}

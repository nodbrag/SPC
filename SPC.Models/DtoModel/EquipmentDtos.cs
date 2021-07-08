/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：Equipment                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SPC.Core.Attribute;

namespace SPC.Models.DtoModel
{
    public class EquipmentDtos
    {
        public class EquipmentDto
        {
        /// <summary>
        /// 设备编号
        /// </summary>
		public Int32 EquipmentId {get;set;}

            /// <summary>
            /// 设备分类
            /// </summary>
       
        public Int32 EquipmentClassId {get;set;}
        /// <summary>
        /// 设备分类名称
        /// </summary>
        [FromEntity("EquipmentClassName", "EquipmentClass")]
        public String EquipmentClassName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
		public String EquipmentType {get;set;}
        /// <summary>
        /// 设备编码
        /// </summary>
		public String EquipmentCode {get;set;}
        /// <summary>
        /// 设备名称
        /// </summary>
		public String EquipmentName {get;set;}
        /// <summary>
        /// 设备描述
        /// </summary>
		public String EquipmentSpec {get;set;}

        /// <summary>
        /// 设备厂商  
        /// </summary>
		public String Manufacturer {get;set;}

        /// <summary>
        /// 投产时间
        /// </summary>
		public DateTime? ProductionDate {get;set;}
        /// <summary>
        /// 生命周期
        /// </summary>
		public Int32 LifeCircleYear {get;set;}

        /// <summary>
        /// 标准容量
        /// </summary>
		public Decimal StandCapacity {get;set;}
        /// <summary>
        /// 描述
        /// </summary>
		public String Memo {get;set;}


        }
        public class EquipmentFilterDto
        {
            /// <summary>
            /// 设备名称
            /// </summary>
            [MappingField("EquipmentName", "EquipmentCode",filterOperator = Core.Models.FilterOperator.Contains)]
            public string EquipmentKeyword { get; set; }
            ///// <summary>
            ///// 设备分类
            ///// </summary>
            //public int EquipmentClassID { get; set; }
            ///// <summary>
            ///// 设备投产开始时间
            ///// </summary>
            //[MappingField("ProductionDate", filterOperator = Core.Models.FilterOperator.IsGreaterThanOrEqaulTo)]
            //public DateTime BeginProductionDate { get; set; }
            ///// <summary>
            ///// 设备投产结束时间
            ///// </summary>
            //[MappingField("ProductionDate", filterOperator = Core.Models.FilterOperator.IsLessThanOrEqaulTo)]
            //public DateTime EndProductionDate { get; set; }
        }
    }
   
}

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：EquipmentClass                                     
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
    public class EquipmentClassDtos
    {
        public class EquipmentClassDto
        {
        /// <summary>
        /// 设备类别id
        /// </summary>
		public Int32 EquipmentClassID {get;set;}

	    /// <summary>
        /// 设备类别code
        /// </summary>
		public String EquipmentClassCode {get;set;}

		/// <summary>
        /// 设备分类名称
        /// </summary>
		public String EquipmentClassName {get;set;}

		/// <summary>
        /// 父编码id
        /// </summary>
		public String ParentID {get;set;}

        /// <summary>
        /// 描述
        /// </summary>
		public String Memo {get;set;}


        }
        public class EquipmentClassFilterDto
        {
            /// <summary>
            /// 设备分类名称或设备分类code 搜索
            /// </summary>
            [MappingField("EquipmentClassName", "EquipmentClassCode",filterOperator = Core.Models.FilterOperator.Contains)]
            public String EquipmentClassKeyword { get; set; }

        }
    }
   
}

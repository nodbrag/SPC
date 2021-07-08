/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：DefectItem                                     
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
    public class DefectItemDtos
    {
        public class DefectItemDto
        {
        /// <summary>
        /// 缺陷项ID
        /// </summary>        
		public Int32 DefectItemID {get;set;}

		/// <summary>
		/// 缺陷项code
		/// </summary>
		
		public String DefectItemCode {get;set;}

		/// <summary>
		///  缺陷项名
		/// </summary>
		public String DefectItemName {get;set;}

		/// <summary>
		///  缺陷项备注
		/// </summary>
		public String Memo {get;set;}


        }
        public class DefectItemFilterDto
        {
            /// <summary>
            /// 缺陷项 coe或name 搜索
            /// </summary>
            [MappingField("DefectItemCode", "DefectItemName", filterOperator = Core.Models.FilterOperator.Contains)]
            public string DefectItemKeyword { get; set; }
        }
    }
   
}

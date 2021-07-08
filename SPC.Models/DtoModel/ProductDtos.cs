/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：Product                                     
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
    public class ProductDtos
    {
        public class ProductDto
        {
        /// <summary>
        /// 产品ID
        /// </summary>
		public Int32 ProductID {get;set;}

		/// <summary>
        /// 产品编号
        /// </summary>
		public String ProductCode {get;set;}

		/// <summary>
        /// 产品名称
        /// </summary>
		public String ProductName {get;set;}


        }
        public class ProductFilterDto
        {
            /// <summary>
            /// 产品code 及产品名搜索
            /// </summary>
            [MappingField("ProductCode", "ProductName",filterOperator = Core.Models.FilterOperator.Contains)]
            public string ProductKeyword { get; set; }

        }
    }
   
}

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：WorkProcess                                     
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
    public class WorkProcessDtos
    {
        public class WorkProcessDto
        {
        /// <summary>
        /// 工序id
        /// </summary>
		public Int32 WorkProcessID {get;set;}

		/// <summary>
		///  工序code
		/// </summary>
		public String WorkProcessCode {get;set;}

		/// <summary>
		///  工序名称
		/// </summary>
		public String WorkProcessName {get;set;}

		/// <summary>
		///  工序描述
		/// </summary>
		public String Memo {get;set;}

            /// <summary>
            /// 缺陷ID
            /// </summary>
        public List<int> DefectItemID { get; set; }
        /// <summary>
        /// 缺陷名称，分开
        /// </summary>
        public  string DefectItemNames { get; set; }

        }
        public class WorkProcessFilterDto
        {
            /// <summary>
            /// 工序code或Name 搜索
            /// </summary>
            [MappingField("WorkProcessCode", "WorkProcessName", filterOperator = Core.Models.FilterOperator.Contains)]
            public string WorkProcessKeyword { get; set; }
        }
    }
   
}

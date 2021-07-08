/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：Parameter                                     
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
    public class ParameterDtos
    {
        public class ParameterDto
        {
        /// <summary>
        /// 参数Id
        /// </summary>
		public Int32 ParameterID {get;set;}

		/// <summary>
        /// 参数code
        /// </summary>
		public String ParameterCode {get;set;}

		/// <summary>
		///  参数名称
		/// </summary>
		public String ParameterName {get;set;}

		/// <summary>
		/// 参数数据类型
		/// </summary>
		public String ParameterDataType {get;set;}

		/// <summary>
		///  参数值
		/// </summary>
		public Int32 ParameterValuePrecision {get;set;}

		/// <summary>
		///  参数值类型
		/// </summary>
		public String ParameterValueType {get;set;}

		/// <summary>
		/// 标准值
		/// </summary>
		public String StandardValue {get;set;}

		/// <summary>
		/// 最小值
		/// </summary>
		public String MinValue {get;set;}

		/// <summary>
		/// 最大值
		/// </summary>
		public String MaxValue {get;set;}


        }
        public class ParameterFilterDto
        {
            /// <summary>
            /// 参数查询过滤 参数编号或名称
            /// </summary>
            [MappingField("ParameterCode", "ParameterName",filterOperator = Core.Models.FilterOperator.Contains)]
            public String ParameterKeyword { get; set; }
        }
    }
   
}

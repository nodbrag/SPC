/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：InspectionOrderDetail                                     
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPC.Models.DtoModel
{
    public class InspectionOrderDetailDtos
    {
        public class InspectionOrderDetailDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int64 InspectionOrderDetailID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(19)]
		public Int64 InspectionOrderID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(50)]
		public String ParameterValue {get;set;}


        }
        public class InspectionOrderDetailFilterDto
        {
           
        }
    }
   
}

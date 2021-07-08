/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：VInspectionOrderDetail                                     
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
    public class VInspectionOrderDetailDtos
    {
        public class VInspectionOrderDetailDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int64 VInspectionOrderDetailID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(19)]
		public Int64 VInspectionOrderID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 DefectItemID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(53)]
		public Double EuclidDistance {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 PointX {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 PointY {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 Width {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 Height {get;set;}


        }
        public class VInspectionOrderDetailFilterDto
        {
           
        }
    }
   
}

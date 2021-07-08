/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：ACL                                     
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
    public class ACLDtos
    {
        public class ACLDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 ACLID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(25)]
		public String VisitorType {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public String VisitorID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public String AccessRight {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(25)]
		public String AccessEntryType {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(10)]
		public String AccessEntryID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(500)]
		public String AccessParams {get;set;}


        }
        public class ACLFilterDto
        {
           
        }
    }
   
}

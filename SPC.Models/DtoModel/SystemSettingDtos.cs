/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：SystemSetting                                     
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
    public class SystemSettingDtos
    {
        public class SystemSettingDto
        {
            		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 SystemSettingID {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(25)]
		public String SystemSettingKey {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(50)]
		public String SystemSettingValue {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		[MaxLength(200)]
		public String Description {get;set;}


        }
        public class SystemSettingFilterDto
        {
           
        }
    }
   
}

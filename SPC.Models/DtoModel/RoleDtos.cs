/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：Role                                     
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
    public class RoleDtos
    {
        public class RoleDto
        {
        /// <summary>
        /// 角色编号
        /// </summary>
		public int RoleID {get;set;}
        
	    /// <summary>
        /// 角色名称
        /// </summary>
		public String RoleName {get;set;}

	    /// <summary>
        /// 描述
        /// </summary>
		public String Description {get;set;}

        }
        public class RoleFilterDto
        {
            [MappingField(filterOperator = Core.Models.FilterOperator.Contains)]
            public String RoleName { get; set; }
        }
    }
   
}

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：User                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SPC.Core.Attribute;
using Newtonsoft.Json.Converters;

namespace SPC.Models.DtoModel
{
    public class UserDtos
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public class UserDto
        {
            /// <summary>
            /// 用户id
            /// </summary>
            public Int32 UserID { get; set; }
            /// <summary>
            /// 用户登录名
            /// </summary>
            public string UserCode { get; set; }
            /// <summary>
            /// 用户真实姓名
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 用户座机电话
            /// </summary>
            public string Telephone { get; set; }
            /// <summary>
            /// 移动电话
            /// </summary>
            public string MobilePhone { get; set; }
            /// <summary>
            /// 电子邮件
            /// </summary>
            public string EMail { get; set; }
            /// <summary>
            /// 是否使用
            /// </summary>
            public bool IsUsed { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public String Description { get; set; }
            /// <summary>
            /// 角色ID
            /// </summary>
            public List<int> RoleID { get; set; }
        }
        /// <summary>
        /// 用户授权信息
        /// </summary>
        public class UserTokenRequest
        {
            /// <summary>
            /// 账户名
            /// </summary>
            public string UserCode { get; set; }
            /// <summary>
            /// 用户密码
            /// </summary>
            public string Password { get; set; }
        }
        /// <summary>
        /// 用户过滤条件
        /// </summary>
        public class UserFilterDto
        {
            /// <summary>
            /// 用户名
            /// </summary>
            [MappingField("UserName","UserCode",filterOperator = Core.Models.FilterOperator.Contains)]
            public string Keyword { get; set; }

        }
    }
   
}

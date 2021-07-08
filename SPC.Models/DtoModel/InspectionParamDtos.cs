/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：InspectionParam                                     
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
    public class InspectionParamDtos
    {
        public class InspectionParamDto
        {
            /// <summary>
            /// 检测参数ID
            /// </summary>
            public Int32 InspectionParamId { get; set; }

            /// <summary>
            /// 产品ID
            /// </summary>
            public Int32 ProductId { get; set; }
            /// <summary>
            /// 产品名称
            /// </summary>
            [FromEntity("ProductName", "Product")]
            public string ProductName { get; set; }
            /// <summary>
            ///  工序ID
            /// </summary>
            public Int32 WorkProcessId { get; set; }
            /// <summary>
            /// 工序名称
            /// </summary>
            [FromEntity("WorkProcessName", "WorkProcess")]
            public String WorkProcessName { get; set; }
            /// <summary>
            ///  参数ID
            /// </summary>
            public Int32 ParameterId { get; set; }
            /// <summary>
            ///  参数名称
            /// </summary>
            [FromEntity("ParameterName", "Parameter")]
            public String ParameterName { get; set; }

        }
        public class InspectionParamFilterDto
        {
            /// <summary>
            /// 工序ID
            /// </summary>
            public int WorkProcessId { get; set; }
            /// <summary>
            /// 产品ID
            /// </summary>
            public Int32 ProductId { get; set; }
        }
    }
   
}

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：SPC                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-07-11 10:12:57                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: SPC.Models.DtoModel                                  
*│　类    名：Task                                     
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
    public class TaskDtos
    {
        public class TaskDto
        {

            /// <summary>
            /// 任务ID
            /// </summary>
            public Int32 TaskId { get; set; }

            /// <summary>
            ///  产品ID
            /// </summary>
            public Int32 ProductId { get; set; }
            /// <summary>
            /// 产品名称
            /// </summary>
            [FromEntity("ProductName", "Product")]
            public String ProductName { get; set; }
            /// <summary>
            /// 工序ID
            /// </summary>
            public Int32 WorkProcessId { get; set; }
            /// <summary>
            /// 工序名
            /// </summary>
            [FromEntity("WorkProcessName", "WorkProcess")]
            public String WorkProcessName { get; set; }

            /// <summary>
            /// 设备ID
            /// </summary>
            public Int32 EquipmentId { get; set; }

            /// <summary>
            /// 设备名
            /// </summary>
            [FromEntity("EquipmentName", "Equipment")]
            public String EquipmentName { get; set; }
            /// <summary>
            /// 设备编号
            /// </summary>
            [FromEntity("EquipmentCode", "Equipment")]
            public String EquipmentCode { get; set; }
            /// <summary>
            /// 批次号
            /// </summary>
            public String BatchNo { get; set; }
            /// <summary>
            /// 总量
            /// </summary>
            public Int32 Quantity { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime BeginDateTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime EndDateTime { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public String Description { get; set; }

            public String UserDefine1 { get; set; }

            public String UserDefine2 { get; set; }

            public String UserDefine3 { get; set; }


            public String UserDefine4 { get; set; }

            public String UserDefine5 { get; set; }

        }
        public class TaskVisionCheckDto {

            /// <summary>
            /// 设备ID
            /// </summary>
            public Int32 EquipmentId { get; set; }
            /// <summary>
            ///  产品ID
            /// </summary>
            public Int32 ProductId { get; set; }
            /// <summary>
            /// 批次号
            /// </summary>
            public String BatchNo { get; set; }
            /// <summary>
            /// 总量
            /// </summary>
            public Int32 Quantity { get; set; }
            /// <summary>
            /// 不良数量
            /// </summary>
            public string BadQuantity { get; set; }
            /// <summary>
            /// 缺陷项总数量
            /// </summary>
            public string DefectItemQuantity { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime? BeginDateTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime? EndDateTime { get; set; }
            /// <summary>
            /// 任务id 这个是你的任务实时分配第一次传送给我，我这边建立的id，返回给你的，之后你要把这个taskid 传送给我，第一次传入taskid 0
            /// </summary>
            public int TaskId { get; set; }


            /// <summary>
            ///  检测缺陷详情
            /// </summary>
            public List<ProductCheck> productChecks { get; set; }

        }
        public class ProductCheck
        {
            /// <summary>
            /// 产品工件序号
            /// </summary>
            public string  ProductSN { get; set; }
            /// <summary>
            /// 工件检测时间
            /// </summary>
            public DateTime? OrderDateTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DefectDetail> defectDetails { get; set; }


        }
        public class DefectDetail {
            /// <summary>
            ///  缺陷ID
            /// </summary>
            public Int32 DefectItemID { get; set; }

            /// <summary>
            ///  距离
            /// </summary>
            public Double EuclidDistance { get; set; }

            /// <summary>
            ///  起点x
            /// </summary>
            public Int32 PointX { get; set; }

            /// <summary>
            ///  起点y
            /// </summary>
            public Int32 PointY { get; set; }

            /// <summary>
            ///  宽度
            /// </summary>
            public Int32 Width { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            public Int32 Height { get; set; }

        }
        public class TaskDimensionOrderDto {
            
            /// <summary>
            /// ID
            /// </summary>
            public Int64 InspectionOrderID { get; set; }

            /// <summary>
            /// 时间
            /// </summary>
            public DateTime OrderDateTime { get; set; }

        }
        public class TaskDimensionDto
        {
            public string filePath { get; set; }
            ///  产品ID
            /// </summary>
            public Int32 ProductID { get; set; }
            /// <summary>
            /// 设备ID
            /// </summary>
            public Int32 EquipmentId { get; set; }

            // <summary>
            /// 批次号
            /// </summary>
            public String BatchNo { get; set; }
        }
        public class TaskDiscreteDto
        {
            /// <summary>
            /// 批次号
            /// </summary>
            public String BatchNo { get; set; }
            /// <summary>
            ///  产品ID
            /// </summary>
            public Int32 ProductID { get; set; }
            /// <summary>
            /// 产品名称
            /// </summary>
            public String ProductName { get; set; }
            /// <summary>
            /// 注射设备名
            /// </summary>
            public String InjectionEquipmentName { get; set; }
            /// <summary>
            /// 摆件设备名
            /// </summary>
            public String SwayEquipmentName { get; set; }
            /// <summary>
            /// 整形设备名
            /// </summary>
            public String PlasticEquipmentName { get; set; }
            /// <summary>
            /// 烧结设备名
            /// </summary>
            public String FiringEquipmentName { get; set; }

            /// <summary>
            /// 注射开始时间
            /// </summary>
            public DateTime STime { get; set; }
            /// <summary>
            /// 模穴位
            /// </summary>
            public String CavityName { get; set; }
            /// <summary>
            /// 模具号
            /// </summary>
            public String MatrixName { get; set; }

        }
        public class TaskDimensionDetailFilterDto
        {
            public String BatchNo { get; set; }
        }
        public class TaskDimensionDetailDto {
            public object obj { get; set; }
            public List<string> cols { get; set; }
            public TaskDimensionDetailDto() {
                cols = new List<string>();
            }
        }
        public class TaskDiscreteFilterDto
        {
            /// <summary>
            /// 结束时间
            /// </summary>
            [MappingField("STime", filterOperator = Core.Models.FilterOperator.IsLessThanOrEqaulTo)]
            public DateTime? EndDateTime { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            [MappingField("STime", filterOperator = Core.Models.FilterOperator.IsGreaterThanOrEqaulTo)]
            public DateTime? BeginDateTime { get; set; }
            /// <summary>
            /// 批次号
            /// </summary>
            [MappingField("BatchNo", filterOperator = Core.Models.FilterOperator.Contains)]
            public String BatchNo { get; set; }

        }
        public class TaskFilterDto
        {
            /// <summary>
            /// 工序
            /// </summary>
            [MappingField("WorkProcessName",filterOperator = Core.Models.FilterOperator.Contains)]
            public string WorkProcessName { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            [MappingField("BeginDateTime",filterOperator = Core.Models.FilterOperator.IsGreaterThanOrEqaulTo)]
            public DateTime? BeginDateTime { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            [MappingField("EndDateTime", filterOperator = Core.Models.FilterOperator.IsLessThanOrEqaulTo)]
            public DateTime? EndDateTime { get; set; }
            /// <summary>
            /// 批次号
            /// </summary>
            [MappingField("BatchNo", filterOperator = Core.Models.FilterOperator.Contains)]
            public String BatchNo { get; set; }
            /// <summary>
            /// 设备ID
            /// </summary>
            public Int32 EquipmentId { get; set; }
            /// <summary>
            ///  产品ID
            /// </summary>
            public Int32 ProductId { get; set; }
        }
    }
   
}

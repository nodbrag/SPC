using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.ChartAlgorithm.PlatoChart;
using SPC.Core.ChartAlgorithm.PChart;
namespace SPC.Models.DtoModel
{
    public class SpcAnalyseDtos
    {

        public class TwoPlistDto {

            public List<PListDto> pListDtos { get; set; }
            public PlatoDto platoDto { get; set; }

        }
        public class FourPlistDto
        {
            public List<PListDto> pListDtos { get; set; }
            public PlatoDto platoDto { get; set; }
            public PDto pDto { get; set; }
        }
        /// <summary>
        /// 不良率列表数据
        /// </summary>
        public class PListDto {
            
            /// <summary>
            /// 设备名称
            /// </summary>
            public string EquipmentName { get; set; }
            /// <summary>
            /// 缺陷名称
            /// </summary>
            public string DefectItemName { get; set; }
            /// <summary>
            /// 不良数
            /// </summary>
            public int badNum { get; set; }
            /// <summary>
            /// 不良率
            /// </summary>
            public string BadRate { get; set; }
            /// <summary>
            /// 总数
            /// </summary>
            public int totalNum { get; set; }

        }
        public class SpcAnalyseFilter {
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime? BeginDateTime { get; set; }
            /// <summary>
            /// 结束数据
            /// </summary>
            public DateTime? EndDateTime { get; set; }
            /// <summary>
            /// 产品id
            /// </summary>
            public int ProductID { get; set; }
            /// <summary>
            /// 设备ID
            /// </summary>
            public int EquipmentID { get; set; }
        }
    }
}

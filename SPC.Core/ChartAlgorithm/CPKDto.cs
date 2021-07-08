using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.ChartAlgorithm
{
    public class CPKDto
    {
        /// <summary>
        /// 规格上限
        /// </summary>
        public double USL { get; set; }
        /// <summary>
        /// 规格下限
        /// </summary>
        public double LSL { get; set; }
        // <summary>
        /// 规格公差
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// 规格中心值
        /// </summary>
        public double U { get; set; }
        /// <summary>
        /// 平均值
        /// </summary>
        public double P { get; set; }
        /// <summary>
        /// 标准方差
        /// </summary>
        public double Sigma { get; set; }
        /// <summary>
        /// 制程准确度
        /// </summary>
        public double CA { get; set; }
        /// <summary>
        ///制程精密度
        /// </summary>
        public double CP { get; set; }
        /// <summary>
        /// 制程能力指数
        /// </summary>
        public double CPK { get; set; }

        /// <summary>
        /// 合格数
        /// </summary>
        public int okNum { get; set; }
        /// <summary>
        /// 不合格数
        /// </summary>
        public int badNum { get; set; }

        public CPKDto(){

            this.okNum = 0;
            this.badNum = 0;
           }

    }
}

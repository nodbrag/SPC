using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Models;


namespace SPC.Core.Dtos
{
    public class Sorting
    {
        /// <summary>
        /// 排序方法
        /// </summary>
        public SortMethod sortMethod { get; set; }
        /// <summary>
        /// 排序字段名称
        /// </summary>
        public string sortFiledName { get; set; }
    }
}

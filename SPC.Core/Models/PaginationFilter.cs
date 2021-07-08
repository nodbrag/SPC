using System;
using System.Collections.Generic;

namespace SPC.Core.Models
{
    public class PaginationFilter
    {
        public PaginationFilter()
        {
            Filters = new List<Filter>();
            Sortings = new List<Tuple<string, SortMethod>>();
        }

        /// <summary>
        /// 过滤条件列表
        /// </summary>
        public List<Filter> Filters { get; set; }

        /// <summary>
        /// 排序规则
        /// </summary>
        public List<Tuple<string, SortMethod>> Sortings { get; set; }

        /// <summary>
        /// 查询页的显示结果数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询页的索引
        /// </summary>
        public int PageIndex { get; set; }
    }
}
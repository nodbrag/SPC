using System;
using System.Collections.Generic;

namespace SPC.Core.Models
{
    public class SortFilter
    {
        public SortFilter()
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
    }
}
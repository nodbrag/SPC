using System.Collections.Generic;

namespace SPC.Core.Models
{
    public class Pagination
    {
        /// <summary>
        /// 查询当前页面结果集
        /// </summary>
        public List<object> Collection { get; set; }
        /// <summary>
        /// 查询结果集总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 查询页的显示结果数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
    }
}
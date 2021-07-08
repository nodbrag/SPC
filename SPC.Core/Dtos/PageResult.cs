using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.Dtos
{
    public class PageResult<TData>
    {
        public PageResult(IReadOnlyList<TData> data,int totalCount)
        {
            this.Items = data;
            if (totalCount == 0)
            {
                this.TotalCount = Items.Count;
            }
            else
            {
                this.TotalCount = totalCount;
            }
        }
        /// <summary>
        /// 数据列表
        /// </summary>
        public IReadOnlyList<TData> Items { get; set; }

        /// <summary>
        /// 总共记录数据
        /// </summary>
        public int TotalCount { get; set; }

        

    }
}

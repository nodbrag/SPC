using System;
using System.Collections.Generic;
using System.Linq;
using SPC.Core.Models;

namespace SPC.Core.Utility
{
    public static class PaginationExtensions
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="collection">结果集</param>
        /// <param name="pageIndex">查询页的索引</param>
        /// <param name="pageSize">查询页的显示结果数量</param>
        /// <returns></returns>
        public static Pagination AsPagination(this IQueryable<object> collection, int? pageIndex, int pageSize)
        {
            //当前页的第一条结果之前的行数
            int index = ((pageIndex ?? 1) - 1) * pageSize;
            int count = collection.Count();
            return new Pagination()
            {
                Collection = collection.Skip(index).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling((double)count / (double)pageSize),
                PageNumber = (index / pageSize) + 1,
                PageSize = pageSize,
                TotalCount = count
            };
        }
    }
}
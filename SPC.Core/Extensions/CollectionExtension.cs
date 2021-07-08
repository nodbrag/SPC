using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Dynamic;

namespace SPC.Core.Extensions
{
    public static class CollectionExtension
    {

        /// <summary>
        /// 判断ICollection是否有值或Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// 添加ICollection中不存在的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);
            return true;
        }
    }
}
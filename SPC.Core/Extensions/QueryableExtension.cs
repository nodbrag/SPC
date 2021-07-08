using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.QueryableExtensions;
using SPC.Core.Models;
using Microsoft.EntityFrameworkCore;
using SPC.Core.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using SPC.Core.Attribute;
using System.Dynamic;


using static System.Linq.Expressions.Expression;

namespace SPC.Core.Extensions
{
    public static class QueryableExtension
    {
        /// <summary>
        /// 根据组合字段获取其属性路径
        /// </summary>
        /// <param name="sourceProperty"></param>
        /// <param name="sourcePropertys"></param>
        /// <param name="targetItem"></param>
        /// <returns></returns>
        private static Expression GetCombinationExpression(Expression sourceProperty, Type sourceType, PropertyInfo targetItem)
        {
            foreach (var item in sourceType.GetProperties().Where(x => x.CanRead))
            {
                if (targetItem.Name.StartsWith(item.Name))
                {
                    if (item != null && item.CanRead && item.PropertyType.IsClass && !item.PropertyType.IsGenericType)
                    {
                        var rightName = targetItem.Name.Substring(item.Name.Length);

                        var complexSourceItem = item.PropertyType.GetProperty(rightName);
                        if (complexSourceItem != null && complexSourceItem.CanRead)
                            return Property(Property(sourceProperty, item), complexSourceItem);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// WhereIf语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="condition"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> func)
        {
            return condition ? query.Where(func) : query;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>        
        /// 需要在Dto做特性映射，如：[AutoMap(typeof(MyClass2))]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> Select<T>(this IQueryable query)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            return query.ProjectTo<T>();
        }

        #region 排序

        /// <summary> 
        /// Linq动态排序 
        /// </summary> 
        /// <typeparam name="T">T</typeparam> 
        /// <param name="source">要排序的数据源</param> 
        /// <param name="value">排序依据（加空格）排序方式</param> 
        /// <returns>IOrderedQueryable</returns> 
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string value)
        {
            string[] arr = value.Split(' ');
            string Name = arr[1].ToUpper() == "DESC" ? "OrderByDescending" : "OrderBy";
            return ApplyOrder<T>(source, arr[0], Name);
        }

        /// <summary> 
        /// Linq动态排序再排序 
        /// </summary> 
        /// <typeparam name="T">T</typeparam> 
        /// <param name="source">要排序的数据源</param> 
        /// <param name="value">排序依据（加空格）排序方式</param> 
        /// <returns>IOrderedQueryable</returns> 
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string value)
        {
            string[] arr = value.Split(' ');
            string Name = arr[1].ToUpper() == "DESC" ? "ThenByDescending" : "ThenBy";
            return ApplyOrder<T>(source, arr[0], Name);
        }
        /// <summary>
        /// Linq多条件排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, ICollection<Sorting> methods)
        {
            string method = "";
            bool isOrderBy = true;
            object result = null;
            foreach (var item in methods)
            {
                //当传入排序条件无效时跳过
                if (item.sortFiledName.IsNullOrEmpty())
                    continue;

                if (isOrderBy == true)
                {
                    method = item.sortMethod == SortMethod.DESC ? "OrderByDescending" : "OrderBy";
                    result = ApplyOrder<T>(source, item.sortFiledName, method);
                    isOrderBy = false;
                    continue;
                }
                method = item.sortMethod == SortMethod.DESC ? "ThenByDescending" : "ThenBy";
                result = ApplyOrder<T>((IOrderedQueryable<T>)result, item.sortFiledName, method);
            }
            return (IOrderedQueryable<T>)result;
        }
        /// <summary>
        /// Linq多条件排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="methods"></param>
        /// <returns></returns>
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, ICollection<Tuple<string, SortMethod>> methods)
        {
            string method = "";
            bool isOrderBy = true;
            object result = null;
            foreach (var item in methods)
            {
                //当传入排序条件无效时跳过
                if (item.Item1.IsNullOrEmpty())
                    continue;

                if (isOrderBy == true)
                {
                    method = item.Item2 == SortMethod.DESC ? "OrderByDescending" : "OrderBy";
                    result = ApplyOrder<T>(source, item.Item1, method);
                    isOrderBy = false;
                    continue;
                }
                method = item.Item2 == SortMethod.DESC ? "ThenByDescending" : "ThenBy";
                result = ApplyOrder<T>((IOrderedQueryable<T>)result, item.Item1, method);
            }
            return (IOrderedQueryable<T>)result;
        }

        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            try
            {
                Type type = typeof(T);
                ParameterExpression arg = Expression.Parameter(type, "a");
                PropertyInfo pi = type.GetProperty(property);
                Expression expr = Expression.Property(arg, pi);
                type = pi.PropertyType;
                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
                object result = typeof(Queryable).GetMethods().Single(
                    a => a.Name == methodName
                         && a.IsGenericMethodDefinition
                         && a.GetGenericArguments().Length == 2
                         && a.GetParameters().Length == 2).MakeGenericMethod(typeof(T), type).Invoke(null, new object[] { source, lambda });
                return (IOrderedQueryable<T>)result;
            }
            catch (Exception)
            {
                throw new Exception("排序字段不匹配");
            }
        }

        #endregion

        #region 获取实体的列表，支持分页
        public static Tuple<List<TEntity>, int> GetAllList<TEntity>(this IQueryable<TEntity> list, int pageIndex, int pageSize, string orderBy = null)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 1 : pageSize;
            if (orderBy.IsNullOrEmpty())
            {
                return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
            else
            {
                return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
        }

        public static Tuple<List<TEntity>, int> GetAllList<TEntity>(this IQueryable<TEntity> all, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy = null)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 1 : pageSize;
            var list = all;
            if (predicate != null)
                list = all.Where(predicate);

            if (orderBy.IsNullOrEmpty())
            {
                return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
            else
            {
                return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
        }

        public static Tuple<List<TEntity>, int> GetAllList<TEntity>(this IQueryable<TEntity> all, string predicate, object[] values, int pageIndex, int pageSize, string orderBy = null)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 1 : pageSize;
            var list = all;
            if (predicate.IsNotNullAndEmpty() && values.Count() > 0)
                list = all.Where(predicate, values);

            if (orderBy.IsNullOrEmpty())
            {
                return new Tuple<List<TEntity>, int>(list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
            else
            {
                return new Tuple<List<TEntity>, int>(list.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(), list.Count());
            }
        }
        #endregion

        /// <summary>
        /// 去重
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector)
        {
            //return collection.GroupBy(groupFunc).Select(group => group.First());
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// 拼接and 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.And);
        }

        /// <summary>
        /// 拼接or 条件语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.Or);
        }

        #region select 扩展
        public static IQueryable<TTarget> SelectMap<TTarget>(this IQueryable<object> query)
        {
            return Queryable.Select(query, GetLamda<object, TTarget>(query.GetType().GetGenericArguments()[0]));
        }

        public static IQueryable<TTarget> SelectMap<TSource, TTarget>(this IQueryable<TSource> query)
        {
            return Queryable.Select(query, GetLamda<TSource, TTarget>());
        }

        public static Expression<Func<TSource, TTarget>> GetLamda<TSource, TTarget>(Type type = null)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            var parameter = Parameter(sourceType);
            Expression propertyParameter;
            if (type != null)
            {
                propertyParameter = Convert(parameter, type);
                sourceType = type;
            }
            else
                propertyParameter = parameter;

            return Lambda<Func<TSource, TTarget>>(GetExpression(propertyParameter, sourceType, targetType), parameter);
        }

        public static MemberInitExpression GetExpression(Expression parameter, Type sourceType, Type targetType)
        {
            var memberBindings = new List<MemberBinding>();
            foreach (var targetItem in targetType.GetProperties().Where(x => x.CanWrite))
            {
                var fromEntityAttr = targetItem.GetCustomAttribute<FromEntityAttribute>();
                if (fromEntityAttr != null)
                {
                    var property = GetFromEntityExpression(parameter, sourceType, fromEntityAttr);
                    if (property != null)
                        memberBindings.Add(Bind(targetItem, property));
                    continue;
                }

                var sourceItem = sourceType.GetProperty(targetItem.Name);
                if (sourceItem == null)//当没有对应的属性时，查找 实体名+属性
                {
                    var complexSourceItemProperty = GetCombinationExpression(parameter, sourceType, targetItem);
                    if (complexSourceItemProperty != null)
                        memberBindings.Add(Bind(targetItem, complexSourceItemProperty));
                    continue;
                }

                //判断实体的读写权限
                if (sourceItem == null || !sourceItem.CanRead)
                    continue;

                //标注NotMapped特性的属性忽略转换
                if (sourceItem.GetCustomAttribute<NotMappedAttribute>() != null)
                    continue;

                var sourceProperty = Property(parameter, sourceItem);

                //当非值类型且类型不相同时
                if (!sourceItem.PropertyType.IsValueType && sourceItem.PropertyType != targetItem.PropertyType && targetItem.PropertyType != targetType)
                {
                    //判断都是(非泛型、非数组)class
                    if (sourceItem.PropertyType.IsClass && targetItem.PropertyType.IsClass
                        && !sourceItem.PropertyType.IsArray && !targetItem.PropertyType.IsArray
                        && !sourceItem.PropertyType.IsGenericType && !targetItem.PropertyType.IsGenericType)
                    {
                        var expression = GetExpression(sourceProperty, sourceItem.PropertyType, targetItem.PropertyType);
                        memberBindings.Add(Bind(targetItem, expression));
                    }
                    continue;
                }

                if (targetItem.PropertyType != sourceItem.PropertyType)
                    continue;

                memberBindings.Add(Bind(targetItem, sourceProperty));
            }

            return MemberInit(New(targetType), memberBindings);
        }

        /// <summary>
        /// 根据FromEntityAttribute 的值获取属性对应的路径
        /// </summary>
        /// <param name="sourceProperty"></param>
        /// <param name="sourceType"></param>
        /// <param name="fromEntityAttribute"></param>
        /// <returns></returns>
        private static Expression GetFromEntityExpression(Expression sourceProperty, Type sourceType, FromEntityAttribute fromEntityAttribute)
        {
            var findType = sourceType;
            var resultProperty = sourceProperty;
            var tableNames = fromEntityAttribute.EntityNames;
            if (tableNames == null)
            {
                var columnProperty = findType.GetProperty(fromEntityAttribute.EntityColuum);
                if (columnProperty == null)
                    return null;
                else
                    return Property(resultProperty, columnProperty);
            }

            for (int i = tableNames.Length - 1; i >= 0; i--)
            {
                var tableProperty = findType.GetProperty(tableNames[i]);
                if (tableProperty == null)
                    return null;

                findType = tableProperty.PropertyType;
                resultProperty = Property(resultProperty, tableProperty);
            }

            var property = findType.GetProperty(fromEntityAttribute.EntityColuum);
            if (property == null)
                return null;
            else
                return Property(resultProperty, property);
        }
        #endregion
    }

    #region ParameterRebinder

    internal class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        public static Expression<T> Compose<T>(Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first  
            var secondBody = ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression   
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }

    #endregion


}

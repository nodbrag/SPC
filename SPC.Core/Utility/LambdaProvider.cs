using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SPC.Core.Models;
using System.Collections.Generic;
using FilterDto = SPC.Core.Models.Filter;
using SPC.Core.Extensions;

namespace SPC.Core.Utility
{
    public class LambdaProvider
    {
        /// <summary>
        /// 通过FilterCondition解析得到Lambda表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetLambdaByFilter<T>(FilterDto filter)
        {
            if (filter.ListFieldName.Count() > 0 && filter.FieldName == null)
            {
                Expression<Func<T, bool>> expression = null;
                foreach (string fieldName in filter.ListFieldName) {

                    if (expression != null)
                    {
                        Expression<Func<T, bool>> newexpression = GetLambdaByFiledName<T>(fieldName, filter.Operator, filter.Value, filter.ListValue);
                        expression = expression.Or(newexpression);
                    }
                    else
                    {
                        expression = GetLambdaByFiledName<T>(fieldName, filter.Operator, filter.Value, filter.ListValue);
                    }
                   
                }
                return expression;
            }
            else
            {
                return GetLambdaByFiledName<T>(filter.FieldName, filter.Operator, filter.Value, filter.ListValue);
            }
        }
        public static Expression<Func<T, bool>> GetLambdaByFiledName<T>(string FieldName,  FilterOperator Operator,string Value, List<string> ListValue)
        {
            ParameterExpression mParameter = Expression.Parameter(typeof(T), FieldName);
            MemberExpression member = Expression.Property(mParameter, FieldName);
            Type type = typeof(T).GetProperty(FieldName).PropertyType;
            //构造单个参数值和多个参数值的常量表达式
            ConstantExpression constant = Expression.Constant(ChangeType(Value, type), type);

            Expression operation = null;
            switch (Operator)
            {
                case FilterOperator.Equals:
                    operation = Expression.Equal(member, constant);
                    break;
                case FilterOperator.DoesNotEqual:
                    operation = Expression.NotEqual(member, constant);
                    break;
                case FilterOperator.IsGreaterThan:
                    operation = Expression.GreaterThan(member, constant);
                    break;
                case FilterOperator.IsGreaterThanOrEqaulTo:
                    operation = Expression.GreaterThanOrEqual(member, constant);
                    break;
                case FilterOperator.IsLessThan:
                    operation = Expression.LessThan(member, constant);
                    break;
                case FilterOperator.IsLessThanOrEqaulTo:
                    operation = Expression.LessThanOrEqual(member, constant);
                    break;
                case FilterOperator.Contains:
                    MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    operation = Expression.Call(member, containsMethod, constant);
                    break;
                case FilterOperator.Or:
                    if (ListValue != null && ListValue.Count() > 0)
                    {
                        foreach (var item in ListValue)
                        {
                            if (operation == null)
                            {
                                operation = Expression.Equal(member,
                                    Expression.Constant(ChangeType(item, type), type));
                                continue;
                            }

                            operation = Expression.Or(operation,
                                Expression.Equal(member,
                                Expression.Constant(ChangeType(item, type), type)));
                        }
                    }
                    break;
                default:
                    break;
            }
            return Expression.Lambda<Func<T, bool>>(operation, mParameter);

        }

        /// <summary>
        /// 通用类型转换
        /// </summary>
        /// <param name="value">需要转换的值</param>
        /// <param name="type">目标类型</param>
        /// <returns></returns>
        public static object ChangeType(object value, Type type)
        {
            if (value == null && type.GetTypeInfo().IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.GetTypeInfo().IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            if (type == typeof(bool))
            {
                if (value.ToString() == bool.TrueString)
                    return true;
                if (value.ToString() == bool.FalseString)
                    return false;
                if (int.TryParse(value.ToString(), out int iValue))
                {
                    return Convert.ToBoolean(iValue);
                }
            }
            return Convert.ChangeType(value, type);
        }
    }
}
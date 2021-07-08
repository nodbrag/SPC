using System.Collections.Generic;

namespace SPC.Core.Models
{
    public class Filter
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        public List<string> ListFieldName { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 字段值列表
        /// </summary>
        public List<string> ListValue { get; set; }

        /// <summary>
        /// 过滤运算符
        /// </summary>
        public FilterOperator Operator { get; set; }

        public Filter() {
            ListFieldName = new List<string>();
            ListValue = new List<string>();
        }
    }

    public enum FilterOperator
    {
        Equals,
        DoesNotEqual,
        IsGreaterThan,
        IsGreaterThanOrEqaulTo,
        IsLessThan,
        IsLessThanOrEqaulTo,
        Contains,
        Or
    }

    public enum SortMethod
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC,
        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }
}
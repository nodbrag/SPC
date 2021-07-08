using System.Collections.Generic;

namespace SPC.Core.Models
{
    public class Filter
    {
        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// �ֶ��б�
        /// </summary>
        public List<string> ListFieldName { get; set; }

        /// <summary>
        /// �ֶ�ֵ
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// �ֶ�ֵ�б�
        /// </summary>
        public List<string> ListValue { get; set; }

        /// <summary>
        /// ���������
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
        /// ����
        /// </summary>
        ASC,
        /// <summary>
        /// ����
        /// </summary>
        DESC
    }
}
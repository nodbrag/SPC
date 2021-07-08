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
        /// ���������б�
        /// </summary>
        public List<Filter> Filters { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public List<Tuple<string, SortMethod>> Sortings { get; set; }

        /// <summary>
        /// ��ѯҳ����ʾ�������
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// ��ѯҳ������
        /// </summary>
        public int PageIndex { get; set; }
    }
}
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
        /// ���������б�
        /// </summary>
        public List<Filter> Filters { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public List<Tuple<string, SortMethod>> Sortings { get; set; }
    }
}
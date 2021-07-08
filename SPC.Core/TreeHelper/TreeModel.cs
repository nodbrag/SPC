using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.TreeHelper
{
    /// <summary>
    /// 返回树信息（树公共类）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeModel<T>
    {
        public string Key { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        public string parentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// 是否为叶子节点
        /// </summary>
        public bool isLeaf { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool expanded { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<T> children { get; set; }
    }
}
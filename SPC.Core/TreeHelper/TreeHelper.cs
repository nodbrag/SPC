using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.TreeHelper
{
    public static class TreeHelper
    {
        public static List<T> TreeGroup<T>(List<T> data, string parentId, int level = 0) where T : TreeModel<T>
        {
            var entitys = data.FindAll(t => t.parentId == parentId);
            var sbdata = new List<T>();
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    item.level = level;
                    item.children = TreeGroup(data, item.Key, level);
                    item.isLeaf = item.children.Count > 0 ? false : true;
                }
                sbdata.AddRange(entitys);
            }
            return sbdata;
        }
    }
}
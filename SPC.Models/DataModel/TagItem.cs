using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class TagItem
    {
        public TagItem()
        {
            EquipmentTag = new HashSet<EquipmentTag>();
        }

        public int TagId { get; set; }
        public string TagTopic { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<EquipmentTag> EquipmentTag { get; set; }
    }
}
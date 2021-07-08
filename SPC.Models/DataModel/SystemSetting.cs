using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class SystemSetting
    {
        public int SystemSettingId { get; set; }
        public string SystemSettingKey { get; set; }
        public string SystemSettingValue { get; set; }
        public string Description { get; set; }
    }
}
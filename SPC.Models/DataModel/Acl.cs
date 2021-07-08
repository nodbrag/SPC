using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Acl
    {
        public int Aclid { get; set; }
        public string VisitorType { get; set; }
        public string VisitorId { get; set; }
        public string AccessRight { get; set; }
        public string AccessEntryType { get; set; }
        public string AccessEntryId { get; set; }
        public string AccessParams { get; set; }
    }
}
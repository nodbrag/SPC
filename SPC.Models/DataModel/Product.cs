using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Product
    {
        public Product()
        {
            InspectionParam = new HashSet<InspectionParam>();
            Task = new HashSet<Task>();
        }

        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<InspectionParam> InspectionParam { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace SPC.Models.DataModel
{
    public partial class Parameter
    {
        public Parameter()
        {
            InspectionOrderDetail = new HashSet<InspectionOrderDetail>();
            InspectionParam = new HashSet<InspectionParam>();
        }

        public int ParameterId { get; set; }
        public string ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDataType { get; set; }
        public int ParameterValuePrecision { get; set; }
        public string ParameterValueType { get; set; }
        public string StandardValue { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }

        public virtual ICollection<InspectionOrderDetail> InspectionOrderDetail { get; set; }
        public virtual ICollection<InspectionParam> InspectionParam { get; set; }
    }
}
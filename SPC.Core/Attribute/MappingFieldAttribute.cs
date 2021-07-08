using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Models;

namespace SPC.Core.Attribute
{
    public class MappingFieldAttribute : System.Attribute
    {
        public string[] _fieldname
        { get; set; }

        public FilterOperator filterOperator { get; set; }

        public MappingFieldAttribute()
        {
            filterOperator = FilterOperator.Equals;
        }

        public MappingFieldAttribute(params string[]  FieldName)
        {
            this._fieldname = FieldName;
            filterOperator = FilterOperator.Equals;
           
        }
        public MappingFieldAttribute(string FieldName)
        {
            this._fieldname = new string[] { FieldName };
            filterOperator = FilterOperator.Equals;
        }
     }
}

using System;
using System.Collections.Generic;
using System.Text;
using SPC.Core.Models;
using SPC.Core.Dtos;
using SPC.Core.Extensions;
using System.Reflection;
using SPC.Core.Attribute;
using System.Linq;


namespace SPC.Core.Utility
{
    public class FilterCondition
    {
        public static List<SPC.Core.Models.Filter> GetFilters<T>(FiterConditionBase<T> conditon) {
           
            if (conditon.Filter == null)
                return new List<Models.Filter>();

            List<SPC.Core.Models.Filter> Filters = new List<SPC.Core.Models.Filter>();
            T filter = conditon.Filter;
            Type t = filter.GetType();//获得该类的Type
            Dictionary<string, string> filterDic = new Dictionary<string, string>();
            foreach (PropertyInfo pi in t.GetProperties())
            {
                string value = pi.GetValue(filter, null).ConvertToString();//用pi.GetValue获得值
                string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                if (value.IsNullOrEmpty())
                    continue;
                if (pi.PropertyType == typeof(DateTime) && value.ConvertToNullableDateTime()==null)
                     continue;
                if (pi.PropertyType == typeof(Int32) && value.ConvertToNullableInt() <= 0)
                      continue;
                if (value.IsNotNullAndEmpty())
                {
                    SPC.Core.Models.Filter fter = new SPC.Core.Models.Filter();

                    FilterOperator filterOperator = FilterOperator.Equals;
                    List<string> fileNames = new List<string>();
                    fileNames.Add(name);
                    object[] MappingFields = pi.GetCustomAttributes(typeof(MappingFieldAttribute), false);
                    if (MappingFields != null && MappingFields.Length > 0)
                    {
                        MappingFieldAttribute attribute = (MappingFieldAttribute)MappingFields[0];
                        filterOperator = attribute.filterOperator;
                        if (attribute._fieldname != null && attribute._fieldname.Count() > 0)
                        {
                            fileNames = attribute._fieldname.ToList();
                        }
                    }

                    fter.ListFieldName = fileNames.ToList();
                    fter.Value = value;
                    fter.Operator = filterOperator;
                    Filters.Add(fter);
                }

            }
            return Filters;
        }
    }
}

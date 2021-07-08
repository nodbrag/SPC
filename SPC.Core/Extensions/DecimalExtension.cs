using System;

namespace SPC.Core.Extensions
{
    public static class DecimalExtension
    {
        public static decimal IsNullThenZero(this decimal? value)
        {
            return null == value ? 0 : (decimal)value;
        }

        public static bool IsNull(this decimal? value)
        {
            return null == value;
        }

        public static string ConvertToStringRemoveTrailingZero(this decimal? value)
        {
            if (value.IsNull())
                return string.Empty;

            return Convert.ToDouble(value.Value).ConvertToString();
        }
    }
}
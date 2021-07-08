namespace SPC.Core.Extensions
{
    public static class IntExtension
    {
        public static int IsNullThenZero(this int? value)
        {
            return null == value ? 0 : (int)value;
        }

        public static bool IsNull(this int? value)
        {
            return null == value;
        }
    }
}
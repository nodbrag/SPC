using Microsoft.AspNetCore.Mvc.Filters;

namespace SPC.Core.Attribute
{
    public class RemarkAttribute : System.Attribute, IFilterMetadata
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Remark">内容</param>
        public RemarkAttribute(string remark)
        {
            Remark = remark;
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Remark { get; set; }
    }
}
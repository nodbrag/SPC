using System;

namespace SPC.Core.Auth
{
    public class PrincipalUser
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 组织机构Id
        /// </summary>
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 登录后的Id值,退出时更新退出时间
        /// </summary>
        public Guid LoginId { get; set; }
    }
}
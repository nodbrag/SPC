using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using SPC.Core.Auth;

namespace SPC.Core.Extensions
{
    public static class HttpContextAccessorExtension
    {
        /// <summary>
        /// 获取当前登录人员信息
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <returns></returns>
        public static PrincipalUser CurrentUser(this IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor?.HttpContext?.User;
            PrincipalUser currentUser = new PrincipalUser();
            if (user != null && user.Identity.IsAuthenticated)
            {
                currentUser.UserId = Guid.Parse(user.FindFirst(JwtRegisteredClaimNames.Jti)?.Value);
                currentUser.Name = user.FindFirst("Name")?.Value;
                currentUser.Code = user.FindFirst("Code")?.Value;
                currentUser.OrganizationId = user.FindFirst("OrganizationId")?.Value == "" ? Guid.Empty : Guid.Parse(user?.FindFirst("OrganizationId")?.Value);
                currentUser.OrganizationName = user.FindFirst("OrganizationName")?.Value;
                currentUser.LoginId = Guid.Parse(user.FindFirst("LoginId")?.Value);
            }
            else
            {
                currentUser.UserId = Guid.Empty;
                currentUser.Name = "NoBody";
            }
            return currentUser;
        }
    }
}
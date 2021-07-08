using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using SPC.Core.Utility;
using SPC.Core.Dtos;

namespace SPC.Core.Filter
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public RequestAuthorizeAttribute()
        {
            
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAllow = context.ActionDescriptor.FilterDescriptors.Any(c => c.Filter.GetType() == typeof(Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter));
            //从http请求的头里面获取身份验证信息，验证Jwt
            if (!isAllow)
            {
                var jwtKey = context.HttpContext.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(jwtKey))
                {
                    try
                    {
                        string token = "";
                        string[] jwtkeys= jwtKey.Trim().Split(" ");
                        if (jwtkeys.Length == 2)
                        {
                            token = jwtkeys[1];
                        }
                        else
                        {
                            token = jwtkeys[0];
                        }
                        string Issuer = ConfigHelper.GetSection("AppSettings")["Issuer"];
                        string Audience = ConfigHelper.GetSection("AppSettings")["Audience"];
                        string SecurityKey = ConfigHelper.GetSection("AppSettings")["SecurityKey"];

                        TokenValidationParameters parms = new TokenValidationParameters
                        {
                            ValidateIssuer = true,//是否验证Issuer
                            ValidateAudience = true,//是否验证Audience
                            ValidateLifetime = true,//是否验证失效时间
                            ValidateIssuerSigningKey = true,//是否验证SecurityKey
                            ValidAudience = Audience,//Audience
                            ValidIssuer = Issuer,//Issuer，这两项和前面签发jwt的设置一致
                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(SecurityKey))//拿到SecurityKey
                        };
                        SecurityToken st;
                        var jwtSecurityToken = new JwtSecurityTokenHandler().ValidateToken(token, parms, out st);
                        
                    }
                    catch (Exception ex)
                    {
                     
                        if (ex.Message.Replace(" ","").Contains("Thetokenisexpired"))
                        {
                            context.Result = new ObjectResult(new BadOpResult("非法请求:Token过期!"));
                        }
                        else
                        {
                            context.Result = new ObjectResult(new BadOpResult("非法请求:Token不合法!"));
                        }
                        
                    }
                }
                //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
                else
                {
                    context.Result = new ObjectResult(new BadOpResult("请求未授权!"));
                }
            }
        }
    }
}

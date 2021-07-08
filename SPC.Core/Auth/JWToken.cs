using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.Extensions.Options;
using SPC.Core.Models;

namespace SPC.Core.Auth
{
    public class JWToken
    {
        
        public static string getToken(IOptions<AppSettings> _appsetting, string UserName,string UserId,int roleid) {

            // push the user’s name into a claim, so we can identify the user later on.
            var claims = new[]
            {
                   new Claim(ClaimTypes.Name,UserName),
                   new Claim("UserId",UserId),
                   new Claim("RoleId",roleid.ToString())

            };
            //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.Value.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
            /***
                Claims (Payload)
                iss: The issuer of the token，token 是给谁的
                sub: The subject of the token，token 主题
                exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                iat: Issued At。 token 创建时间， Unix 时间戳格式
                jti: JWT ID。针对当前 token 的唯一标识
                除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
             ***/
            var token = new JwtSecurityToken(
                issuer: _appsetting.Value.Issuer,
                audience: _appsetting.Value.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_appsetting.Value.ExpiresTime),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}

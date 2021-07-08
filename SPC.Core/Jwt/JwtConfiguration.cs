using System;
using System.Collections.Generic;
using System.Text;

namespace SPC.Core.Jwt
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
    }
}

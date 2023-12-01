﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.ApiHelpers.JwtHelper.Encyption
{
    public class SecurityKeyHelper
    {
        protected SecurityKeyHelper()
        {
            
        }
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}

﻿namespace Core.ApiHelpers.JwtHelper.Models
{
    public class JwtOptions
    {
        public string Audience { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; } = null!;
    }
}

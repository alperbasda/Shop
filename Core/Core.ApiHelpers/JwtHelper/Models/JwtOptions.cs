namespace Core.ApiHelpers.JwtHelper.Models
{
    public class JwtOptions
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}

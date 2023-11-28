namespace Core.ApiHelpers.JwtHelper.Models
{
    public class TokenParameters
    {
        public string[]? ClientIds { get; set; }

        public Guid UserId { get; set; } = Guid.Empty;

        public string UserName { get; set; }

        public string IpAddress { get; set; }

        public string UserLanguage { get; set; } = "TR";

        public string AccessToken { get; set; }

        public string[] Scopes { get; set; }

        public bool IsSuperUser { get; set; } = false;
    }
}

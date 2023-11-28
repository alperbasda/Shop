namespace Shop.UI.Api.Options;

public class JwtTokenOptions
{
    public string Audience { get; set; }

    public string Issuer { get; set; }

    public string SecurityKey { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }
}

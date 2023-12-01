namespace Shop.UI.Api.Options;

public class JwtTokenOptions
{
    public string Audience { get; set; } = null!;

    public string Issuer { get; set; } = null!;

    public string SecurityKey { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string ClientSecret { get; set; } = null!;
}

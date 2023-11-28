using Core.ApiHelpers.JwtHelper.Encyption;
using Core.ApiHelpers.JwtHelper.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.ApiHelpers.Middlewares;


public static class AddJwtAuthenticationMiddleware
{
    public static JwtOptions JwtOptions { get; private set; }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, JwtOptions tokenOptions)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddSingleton<JwtOptions>(sp =>
        {
            return tokenOptions;
        });

        JwtOptions = new JwtOptions();

        services.AddScoped<TokenParameters>();

        return services;
    }

    public static IApplicationBuilder UseJwtParameters(this IApplicationBuilder app)
    {
        return app.UseMiddleware<JwtParameterMiddleware>();
    }
}

public class JwtParameterMiddleware
{
    private readonly RequestDelegate _next;

    public JwtParameterMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, TokenParameters parameters)
    {
        parameters.IpAddress = context.Connection.RemoteIpAddress.ToString();
        //Önce dili alayım ki token çözülemese bile hata mesajını uygun dil ile verebileyim.
        var lang = context.Request.Headers.FirstOrDefault(w => w.Key == "Accept-Language");
        if (!string.IsNullOrEmpty(lang.Value))
        {
            parameters.UserLanguage = lang.Value;
        }


        StringValues jwt;
        if (context.Request.Headers.TryGetValue("Authorization", out jwt))
        {
            parameters.AccessToken = jwt;
            var handler = new JwtSecurityTokenHandler();
            var splitted = jwt.ToString().Split(' ');
            if (splitted.Length > 1)
            {
                var token = handler.ReadJwtToken(jwt.ToString().Split(' ')[1]);
                if (token != null)
                {
                    var identity = new ClaimsIdentity(token.Claims, "basic");
                    context.User = new ClaimsPrincipal(identity);
                    if (!string.IsNullOrEmpty(context?.User?.Identity?.Name))
                        parameters.UserName = context.User.Identity.Name;

                    parameters.UserId = Guid.Empty;
                    var userIdClaim = token.Claims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrEmpty(userIdClaim))
                        parameters.UserId = Guid.Parse(userIdClaim);

                    var clientIdClaim = token.Claims.FirstOrDefault(w => w.Type == JwtRegisteredClaimNames.Sub)?.Value;
                    if (!string.IsNullOrEmpty(clientIdClaim))
                        parameters.ClientIds = clientIdClaim.Split(',');

                    parameters.IsSuperUser = token.Claims.Any(w => w.Type == "scope" && w.Value == "super_user_scope");
                }
            }
        }
        await _next(context);
    }
}



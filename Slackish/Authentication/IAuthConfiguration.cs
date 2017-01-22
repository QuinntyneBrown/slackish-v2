namespace Slackish.Authentication
{
    public interface IAuthConfiguration
    {
        string AuthType { get; set; }
        string TokenPath { get; set; }
        int ExpirationMinutes { get; set; }
        string JwtKey { get; set; }
        string JwtAudience { get; set; }
        string JwtIssuer { get; set; }
    }
}

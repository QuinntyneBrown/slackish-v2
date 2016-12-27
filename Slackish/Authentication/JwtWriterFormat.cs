using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using System;
using Microsoft.Owin.Security.OAuth;
using Slackish.Configuration;

namespace Slackish.Authentication
{
    public class JwtWriterFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly OAuthAuthorizationServerOptions _options;
        protected IAuthConfiguration _authConfiguration { get { return _lazyAuthConfiguration.Value; } }
        protected Lazy<IAuthConfiguration> _lazyAuthConfiguration;

        public JwtWriterFormat(Lazy<IAuthConfiguration> lazyAuthConfiguration, OAuthAuthorizationServerOptions options)
        {
            _options = options;
            _lazyAuthConfiguration = lazyAuthConfiguration; 
        }

        public string SignatureAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"; }
        }

        public string DigestAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmlenc#sha256"; }
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var issuer = _authConfiguration.JwtIssuer;
            var audience = _authConfiguration.JwtAudience;
            var key = Convert.FromBase64String(_authConfiguration.JwtKey);
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_options.AccessTokenExpireTimeSpan.TotalMinutes);
            var signingCredentials = new SigningCredentials(
                                        new InMemorySymmetricSecurityKey(key),
                                        SignatureAlgorithm,
                                        DigestAlgorithm);
            var token = new JwtSecurityToken(issuer, audience, data.Identity.Claims,
                                             now, expires, signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}

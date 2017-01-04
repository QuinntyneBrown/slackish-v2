using Slackish.Configuration;
using Slackish.Utilities;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using MediatR;

namespace Slackish.Authentication
{
    public class OAuthOptions : OAuthAuthorizationServerOptions
    {
        public OAuthOptions(Lazy<IAuthConfiguration> lazyAuthConfiguration, IMediator mediator)
        {
            _lazyAuthConfiguration = lazyAuthConfiguration;
            TokenEndpointPath = new PathString(_authConfiguration.TokenPath);
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(_authConfiguration.ExpirationMinutes);
            AccessTokenFormat = new JwtWriterFormat(lazyAuthConfiguration, this);
            Provider = new OAuthProvider(lazyAuthConfiguration, mediator);
            AllowInsecureHttp = true;
        }

        protected IAuthConfiguration _authConfiguration { get { return _lazyAuthConfiguration.Value; } }
        protected Lazy<IAuthConfiguration> _lazyAuthConfiguration;

    }
}

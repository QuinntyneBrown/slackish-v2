using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Owin;
using Microsoft.Owin.Security;
using System;
using System.IdentityModel.Tokens;
using System.Security.Claims;

using Microsoft.Practices.Unity;

using static Slackish.UnityConfiguration;

namespace Slackish.Security
{
    public class QueryStringBearerAuthorizeAttribute : AuthorizeAttribute
    {
        public QueryStringBearerAuthorizeAttribute()
        {
            _authConfiguration = GetContainer().Resolve<Lazy<IAuthConfiguration>>().Value;
            _jwtWriterFormat = GetContainer().Resolve<ISecureDataFormat<AuthenticationTicket>>();
        }

        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            try
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

                var userJwtToken = request.QueryString.Get("Bearer");

                var authenticationTicket = _jwtWriterFormat.Unprotect(userJwtToken);

                if (authenticationTicket == null)
                {
                    return false;
                }

                var currentUtc = DateTimeOffset.UtcNow;

                if (authenticationTicket.Properties.ExpiresUtc.HasValue && authenticationTicket.Properties.ExpiresUtc.Value < currentUtc)
                {
                    return false;
                }

                if (!authenticationTicket.Identity.IsAuthenticated)
                {
                    return false;
                }

                var jwtSecurityToken = jwtSecurityTokenHandler.ReadToken(userJwtToken) as JwtSecurityToken;

                if (string.IsNullOrEmpty(userJwtToken))
                {
                    return false;
                }

                var newClaimsPrincipal = new ClaimsPrincipal(authenticationTicket.Identity);

                var existingPrincipal = request.User;
                if (existingPrincipal != null)
                {
                    var existingClaimsPrincipal = existingPrincipal as ClaimsPrincipal;
                    if (existingClaimsPrincipal == null)
                    {
                        System.Security.Principal.IIdentity existingIdentity = existingPrincipal.Identity;
                        if (existingIdentity.IsAuthenticated)
                        {
                            newClaimsPrincipal.AddIdentity(existingIdentity as ClaimsIdentity ?? new ClaimsIdentity(existingIdentity));
                        }
                    }
                    else
                    {
                        foreach (var existingClaimsIdentity in existingClaimsPrincipal.Identities)
                        {
                            if (existingClaimsIdentity.IsAuthenticated)
                            {
                                newClaimsPrincipal.AddIdentity(existingClaimsIdentity);
                            }
                        }
                    }
                }

                request.Environment["server.User"] = newClaimsPrincipal;

                return true; ;

            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return false;
        }
 
        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            var connectionId = hubIncomingInvokerContext.Hub.Context.ConnectionId;
            var environment = hubIncomingInvokerContext.Hub.Context.Request.Environment;
            var principal = environment["server.User"] as System.Security.Principal.IPrincipal;
            if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                hubIncomingInvokerContext.Hub.Context = new HubCallerContext(new ServerRequest(environment), connectionId);
                return true;
            }
            else
            {
                return false;
            }
        }

        private IAuthConfiguration _authConfiguration;
        private ISecureDataFormat<AuthenticationTicket> _jwtWriterFormat;
    }
}
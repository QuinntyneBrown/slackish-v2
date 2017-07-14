using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;

namespace Slackish.Features.Core
{
    public class UserIdProvider : IUserIdProvider
    {
        public UserIdProvider()
        {
            _jwtWriterFormat = UnityConfiguration.GetContainer().Resolve<ISecureDataFormat<AuthenticationTicket>>();
        }

        [InjectionConstructor]
        public UserIdProvider(ISecureDataFormat<AuthenticationTicket> jwtWriterFormat) {
            _jwtWriterFormat = jwtWriterFormat;
        }

        public string GetUserId(IRequest request)
        {
            var token = request.QueryString.Get("bearer");
            if (!string.IsNullOrEmpty(token))
            {
                var authenticationTicket = _jwtWriterFormat.Unprotect(token);
                return authenticationTicket.Identity.Name;
            }
            return null;
        }

        private readonly ISecureDataFormat<AuthenticationTicket> _jwtWriterFormat;
    }
}
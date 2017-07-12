using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace Slackish.Features.Core
{
    public class BaseHub: Hub
    {
        public BaseHub(ISecureDataFormat<AuthenticationTicket> jwtWriterFormat) {

            _jwtWriterFormat = jwtWriterFormat;
            var token = Context.Request.QueryString.Get("Bearer");

            if (!string.IsNullOrEmpty(token) && Context.User == null)
            {
                var authenticationTicket = _jwtWriterFormat.Unprotect(token);                
                Context.Request.GetHttpContext().User = new ClaimsPrincipal(authenticationTicket.Identity);
            }
        }
        

        private ISecureDataFormat<AuthenticationTicket> _jwtWriterFormat;
    }
}

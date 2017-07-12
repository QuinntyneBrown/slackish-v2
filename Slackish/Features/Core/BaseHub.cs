using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Slackish.Features.Core
{
    public class BaseHub: Hub
    {
        public BaseHub() {
            if(!string.IsNullOrEmpty(Context.Request.QueryString.Get("Bearer")) && Context.User == null)
            {
                Context.Request.GetHttpContext().User = SetCurrentUserIdentity().Result;
            }
        }

        private async Task<System.Security.Principal.IPrincipal> SetCurrentUserIdentity()
        {
            throw new NotImplementedException();
        }
    }
}

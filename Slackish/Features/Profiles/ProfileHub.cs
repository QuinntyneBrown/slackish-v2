using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Security;
using Slackish.Features.Core;
using Slackish.Security;

namespace Slackish.Features.Profiles
{
    [QueryStringBearerAuthorize]
    [HubName("profileHub")]
    public class ProfileHub: BaseHub
    {
        public ProfileHub(ISecureDataFormat<AuthenticationTicket> jwtWriterFormat)
            :base(jwtWriterFormat)
        {

        }
        public void Send(string username, string message)
        {
            Clients.All.broadcastMessage(new { username = username, message = message });
        }
    }
}

using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Security;
using Slackish.Features.Core;
using Slackish.Security;

namespace Slackish.Features.Messages
{
    [QueryStringBearerAuthorize]
    [HubName("messageHub")]
    public class MessageHub: BaseHub
    {
        public MessageHub(ISecureDataFormat<AuthenticationTicket> jwtWriterFormat)
            :base(jwtWriterFormat)
        { }

        public void Send(MessageApiModel model) 
            => Clients.Others.broadcastMessage(model);
    }
}

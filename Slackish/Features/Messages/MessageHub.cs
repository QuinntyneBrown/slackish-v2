using Microsoft.AspNet.SignalR.Hubs;
using Slackish.Features.Core;
using Slackish.Security;

namespace Slackish.Features.Messages
{
    [QueryStringBearerAuthorize]
    [HubName("messageHub")]
    public class MessageHub: BaseHub
    {
        public void Send(MessageApiModel model) 
            => Clients.Others.broadcastMessage(model);
    }
}

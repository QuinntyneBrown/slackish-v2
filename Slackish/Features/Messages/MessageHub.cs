using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Featrues.Messages
{
    [HubName("messageHub")]
    public class MessageHub: Hub
    {
        public void Send(MessageApiModel model) 
            => Clients.Others.broadcastMessage(model);
    }
}

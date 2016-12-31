using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Slackish.ApiModels;

namespace Slackish.Hubs
{
    [HubName("messageHub")]
    public class MessageHub: Hub
    {
        public void Send(MessageApiModel model) 
            => Clients.Others.broadcastMessage(model);
    }
}

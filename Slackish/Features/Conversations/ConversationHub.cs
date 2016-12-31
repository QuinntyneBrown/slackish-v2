using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Hubs
{
    [HubName("conversationHub")]
    public class ConversationHub: Hub
    {
    }
}

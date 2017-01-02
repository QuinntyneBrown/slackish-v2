using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Featrues.Conversations
{
    [HubName("conversationHub")]
    public class ConversationHub: Hub
    {
    }
}

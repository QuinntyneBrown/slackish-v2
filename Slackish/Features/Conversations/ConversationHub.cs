using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Features.Conversations
{
    [HubName("conversationHub")]
    public class ConversationHub: Hub
    {
    }
}

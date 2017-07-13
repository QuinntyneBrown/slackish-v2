using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Slackish.Security;
using Slackish.Features.Core;
using Microsoft.Owin.Security;

namespace Slackish.Features.Conversations
{
    [QueryStringBearerAuthorize]
    [HubName("conversationHub")]
    public class ConversationHub: BaseHub
    {
        public ConversationHub(ISecureDataFormat<AuthenticationTicket> jwtWriterFormat)
            :base(jwtWriterFormat)
        { }       
    }
}

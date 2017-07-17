using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Security;
using Slackish.Security;
using Slackish.Features.Core;


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

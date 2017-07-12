using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Slackish.Data;
using Slackish.Security;
using Slackish.Features.Core;

namespace Slackish.Features.Conversations
{
    [QueryStringBearerAuthorize]
    [HubName("conversationHub")]
    public class ConversationHub: BaseHub
    {
        public override Task OnConnected()
        {
            AssignToTenantGroup();
            return base.OnConnected();
        }

        public void AssignToTenantGroup() {
            if (Context.User.Identity.IsAuthenticated)
            {

            }
        }
        public void Send(string username, string message)
        {
            Clients.All.broadcastMessage(new { username = username, message = message });
        }

        private readonly SlackishContext _contenxt;
    }
}

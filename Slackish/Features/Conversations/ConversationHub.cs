using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Slackish.Data;

namespace Slackish.Features.Conversations
{
    [HubName("conversationHub")]
    public class ConversationHub: Hub
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

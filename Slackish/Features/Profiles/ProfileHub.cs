using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace Slackish.Features.Profiles
{
    [HubName("profileHub")]
    public class ProfileHub: Hub
    {
        public void Send(string username, string message, Guid? tenantUniqueId)
        {
            Clients.All.broadcastMessage(new { username = username, message = message });
        }
    }
}

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Hubs
{
    [HubName("profileHub")]
    public class ProfileHub: Hub
    {
    }
}

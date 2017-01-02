using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Featrues.Profiles
{
    [HubName("profileHub")]
    public class ProfileHub: Hub
    {
    }
}

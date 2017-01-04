using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Slackish.Features.Profiles
{
    [HubName("profileHub")]
    public class ProfileHub: Hub
    {
    }
}

using System.Collections.Generic;
using System.Security.Claims;

namespace Slackish.Authentication
{
    public class GetClaimsForUserResponse
    {
        public ICollection<Claim> Claims { get; set; }
    }
}

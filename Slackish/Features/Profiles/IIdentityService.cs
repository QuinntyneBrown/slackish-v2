using Slackish.Features.Profiles;
using Slackish.Reponses;
using Slackish.Requests;
using System.Collections.Generic;
using System.Security.Claims;

namespace Slackish.Services
{
    public interface IIdentityService
    {

        TokenResponse TryToRegister(RegistrationRequest request);

        bool AuthenticateUser(string username, string password);

        ICollection<Claim> GetClaimsForUser(string username);
    }
}

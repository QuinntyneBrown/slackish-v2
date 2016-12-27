using Slackish.Features.Profiles;
using Slackish.Reponses;
using Slackish.Requests;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Slackish.Services
{
    public class IdentityService : IIdentityService
    {
        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ICollection<Claim> GetClaimsForUser(string username)
        {
            throw new NotImplementedException();
        }

        public TokenResponse TryToRegister(RegistrationRequest registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

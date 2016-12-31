using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Authentication;

namespace Slackish.Features.Profiles
{    
    public class AuthenticateCommand : IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        public Task<AuthenticateResponse> Handle(AuthenticateRequest message)
        {
            throw new NotImplementedException();
        }
    }
}

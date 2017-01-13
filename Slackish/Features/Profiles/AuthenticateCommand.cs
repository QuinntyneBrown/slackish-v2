using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Authentication;
using Slackish.Data;
using Slackish.Utilities;

namespace Slackish.Features.Profiles
{    
    public class AuthenticateCommand 
    {
        public class AuthenticateCommandHandler : IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>
        {
            public AuthenticateCommandHandler(SlackishDbContext slackishDbContext, ICache cache)
            {
                _slackishDbContext = slackishDbContext;
                _cache = cache;
            }

            public Task<AuthenticateResponse> Handle(AuthenticateRequest message)
            {
                throw new NotImplementedException();
            }

            protected SlackishDbContext _slackishDbContext { get; set; }
            protected ICache _cache { get; set; }
        }
    }
}

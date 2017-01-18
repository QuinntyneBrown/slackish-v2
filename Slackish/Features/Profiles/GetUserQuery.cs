using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Data.Entity;
using Slackish.Utilities;

namespace Slackish.Features.Profiles
{
    public class GetUserQuery
    {
        public class GetUserRequest :
            IAsyncRequest<GetUserResponse>
        {
            public string Username { get; set; }
        }

        public class GetUserResponse
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserHandler : IAsyncRequestHandler<GetUserRequest, GetUserResponse>
        {
            public GetUserHandler(SlackishDbContext slackishDbContext, ICache cache)
            {
                _slackishDbContext = slackishDbContext;
                _cache = cache;
            }

            public async Task<GetUserResponse> Handle(GetUserRequest message)
                => new GetUserResponse()
                {
                    User = UserApiModel.FromUser(await _cache
                        .FromCacheOrServiceAsync(() => _slackishDbContext
                        .Users
                        .Where(x => x.Username == message.Username)
                        .SingleAsync(), $"[GetUserQuery] {message.Username}"))
                };
            
            protected SlackishDbContext _slackishDbContext { get; set; }
            protected ICache _cache { get; set; }
        }
    }
}

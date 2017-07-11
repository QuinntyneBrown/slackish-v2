using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Data.Entity;
using Slackish.Features.Core;

namespace Slackish.Features.Profiles
{
    public class GetUserQuery
    {
        public class GetUserRequest : IRequest<GetUserResponse>
        {
            public string Username { get; set; }
        }

        public class GetUserResponse
        {
            public UserApiModel User { get; set; }
        }

        public class GetUserHandler : IAsyncRequestHandler<GetUserRequest, GetUserResponse>
        {
            public GetUserHandler(SlackishContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetUserResponse> Handle(GetUserRequest message)
                => new GetUserResponse()
                {
                    User = UserApiModel.FromUser(await _cache
                        .FromCacheOrServiceAsync(() => _context
                        .Users
                        .Where(x => x.Username == message.Username)
                        .SingleAsync(), $"[GetUserQuery] {message.Username}"))
                };
            
            protected SlackishContext _context { get; set; }
            protected ICache _cache { get; set; }
        }
    }
}

using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Data.Entity;
using Slackish.Features.Core;

namespace Slackish.Features.Profiles
{
    public class GetCurrentProfileQuery
    {
        public class GetCurrentProfileRequest : IRequest<GetCurrentProfileResponse>
        {
            public string Username { get; set; }
        }

        public class GetCurrentProfileResponse
        {
            public ProfileApiModel Profile { get; set; }
        }

        public class GetCurrentProfileHandler : IAsyncRequestHandler<GetCurrentProfileRequest, GetCurrentProfileResponse>
        {
            public GetCurrentProfileHandler(SlackishDbContext slackishDbContext, ICache cache)
            {
                _slackishDbContext = slackishDbContext;
                _cache = cache;
            }

            public async Task<GetCurrentProfileResponse> Handle(GetCurrentProfileRequest message)
            {
                var profile = await _cache.FromCacheOrServiceAsync(() => _slackishDbContext
                    .Profiles
                    .SingleAsync(x => x.User.Username == message.Username),"[Profile] CurrentProfile");

                return new GetCurrentProfileResponse()
                {
                    Profile = ProfileApiModel.FromProfile(profile)
                };
                
            }

            private SlackishDbContext _slackishDbContext { get; set; }
            private ICache _cache { get; set; }
        }
    }
}

using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Data.Entity;
using Slackish.Features.Core;
using System;

namespace Slackish.Features.Profiles
{
    public class GetCurrentProfileQuery
    {
        public class GetCurrentProfileRequest : IRequest<GetCurrentProfileResponse>
        {
            public string Username { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class GetCurrentProfileResponse
        {
            public ProfileApiModel Profile { get; set; }
        }

        public class GetCurrentProfileHandler : IAsyncRequestHandler<GetCurrentProfileRequest, GetCurrentProfileResponse>
        {
            public GetCurrentProfileHandler(SlackishContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetCurrentProfileResponse> Handle(GetCurrentProfileRequest request)
            {
                var profile = await _cache.FromCacheOrServiceAsync(() => _context
                    .Profiles
                    .SingleAsync(x => x.User.Username == request.Username),$"[Profile] CurrentProfile: {request.Username}");

                return new GetCurrentProfileResponse()
                {
                    Profile = ProfileApiModel.FromProfile(profile)
                };                
            }

            private SlackishContext _context { get; set; }
            private ICache _cache { get; set; }
        }
    }
}

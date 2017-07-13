using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Slackish.Features.Core;

namespace Slackish.Features.Profiles
{
    public class GetOtherProfilesQuery
    {
        public class Request : IRequest<GetOtherProfilesResponse>
        {
            public string Username { get; set; }
            public int OtherProfileId { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class GetOtherProfilesResponse
        {
            public ICollection<ProfileApiModel> Profiles { get; set; } = new HashSet<ProfileApiModel>();
        }

        public class GetOtherProfilesHandler : IAsyncRequestHandler<Request, GetOtherProfilesResponse>
        {
            public GetOtherProfilesHandler(SlackishContext context)
            {
                _context = context;
            }

            public async Task<GetOtherProfilesResponse> Handle(Request request)
            {                
                var profiles = await _cache.FromCacheOrServiceAsync(() => _context
                    .Profiles
                    .Where(x => x.User.Username != request.Username)
                    .ToListAsync(), $"[Profiles] GetOtherProfilesQuery: {request.Username}");

                return new GetOtherProfilesResponse()
                {
                    Profiles = profiles
                    .Select(x => ProfileApiModel.FromProfile(x))
                    .ToList()
                };
            }

            protected SlackishContext _context { get; set; }
            protected readonly ICache _cache;
        }
    }
}

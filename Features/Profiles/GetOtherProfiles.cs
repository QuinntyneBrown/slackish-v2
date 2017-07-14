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
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class Response
        {
            public ICollection<ProfileApiModel> Profiles { get; set; } = new HashSet<ProfileApiModel>();
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext context, ICacheProvider cacheProvider)
            {
                _context = context;
                _cache = cacheProvider.GetCache();
            }

            public async Task<Response> Handle(Request request)
            {                
                var profiles = await _cache.FromCacheOrServiceAsync(() => _context
                    .Profiles
                    .Include(x => x.Tenant)
                    .Where(x => x.User.Username != request.Username && x.Tenant.UniqueId == request.TenantUniqueId)
                    .ToListAsync(), $"[Profiles] GetOtherProfilesQuery: {request.Username}");

                return new Response()
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

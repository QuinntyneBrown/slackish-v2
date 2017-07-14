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
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class Response
        {
            public ProfileApiModel Profile { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var profile = await _cache.FromCacheOrServiceAsync(() => _context
                    .Profiles
                    .Include(x => x.Tenant)
                    .SingleAsync(x => x.User.Username == request.Username && x.User.Tenant.UniqueId == request.TenantUniqueId),
                    $"[Profile] CurrentProfile: {request.TenantUniqueId}-{request.Username}");

                return new Response()
                {
                    Profile = ProfileApiModel.FromProfile(profile)
                };                
            }

            private SlackishContext _context { get; set; }
            private ICache _cache { get; set; }
        }
    }
}

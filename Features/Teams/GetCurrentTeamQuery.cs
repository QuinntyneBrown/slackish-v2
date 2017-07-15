using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Data.Entity;
using Slackish.Features.Core;
using System;
using System.Linq;

namespace Slackish.Features.Teams
{
    public class GetCurrentTeamQuery
    {
        public class Request : IRequest<Response>
        {
            public Guid TenantUniqueId { get; set; }
            public string Username { get; set; }
        }

        public class Response
        {
            public TeamApiModel Team { get; set; }
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
                var team = await _cache.FromCacheOrServiceAsync(() => _context
                    .Users
                    .Include(x => x.Tenant)
                    .Include(x => x.CurrentTeam)
                    .Where(x => x.Username == request.Username && x.Tenant.UniqueId == request.TenantUniqueId)
                    .Select(x => x.CurrentTeam)
                    .SingleAsync(),$"[Current Team] CurrentTeam: {request.TenantUniqueId}-{request.Username}");

                return new Response()
                {
                    Team = TeamApiModel.FromTeam(team)
                };
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

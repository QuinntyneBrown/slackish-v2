using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Teams
{
    public class GetTeamsQuery
    {
        public class Request : IRequest<Response> { 
            public Guid TenantUniqueId { get; set; }       
        }

        public class Response
        {
            public ICollection<TeamApiModel> Teams { get; set; } = new HashSet<TeamApiModel>();
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
                var teams = await _context.Teams
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new Response()
                {
                    Teams = teams.Select(x => TeamApiModel.FromTeam(x)).ToList()
                };
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Slackish.Data;
using Slackish.Data.Model;
using Slackish.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Teams
{
    public class AddOrUpdateTeamCommand
    {
        public class Request : IRequest<Response>
        {
            public TeamApiModel Team { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class Response { }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var entity = await _context.Teams
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Team.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Teams.Add(entity = new Team() { TenantId = tenant.Id });
                }

                entity.Name = request.Team.Name;
                
                await _context.SaveChangesAsync();

                return new Response();
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

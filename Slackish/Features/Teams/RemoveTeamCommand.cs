using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Slackish.Features.Teams
{
    public class RemoveTeamCommand
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; } 
        }

        public class Response { }

        public class RemoveTeamHandler : IAsyncRequestHandler<Request, Response>
        {
            public RemoveTeamHandler(SlackishContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var team = await _context.Teams.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                team.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new Response();
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Slackish.Features.Teams
{
    public class GetTeamByIdQuery
    {
        public class Request : IRequest<Response> { 
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; }
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
                return new Response()
                {
                    Team = TeamApiModel.FromTeam(await _context.Teams
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

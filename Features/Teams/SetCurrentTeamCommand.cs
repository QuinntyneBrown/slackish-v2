using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Slackish.Features.Teams
{
    public class SetCurrentTeamCommand
    {
        public class Request : IRequest<Response>
        {
            public Guid TenantUniqueId { get; set; }
            public string Username { get; set; }
            public string TeamName { get; set; }
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
                var user = await _context.Users.Include(x => x.CurrentTeam).SingleAsync(x => x.Username == request.Username);

                var team = await _cache.FromCacheOrServiceAsync(() => _context.Teams.SingleAsync(x => x.Name == request.TeamName),$"[Team] {request.TeamName}");                

                user.CurrentTeamId = team.Id;

                await _context.SaveChangesAsync();

                _cache.Remove($"[Current Team] CurrentTeam: {request.TenantUniqueId}-{request.Username}");

                return new Response();
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}

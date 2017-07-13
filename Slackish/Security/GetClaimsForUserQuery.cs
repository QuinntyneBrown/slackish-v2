using MediatR;
using Slackish.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Claims;

namespace Slackish.Security
{
    public class GetClaimsForUserQuery
    {
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
        }

        public class Response
        {
            public ICollection<Claim> Claims { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request message)
            {

                var claims = new List<System.Security.Claims.Claim>();

                var user = await _context.Users    
                    .Include(x=>x.Tenant)
                    .SingleAsync(x => x.Username == message.Username);

                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", message.Username));

                claims.Add(new Claim("tenant", $"{user.Tenant.UniqueId}"));

                return new Response()
                {
                    Claims = claims
                };
            }

            private readonly SlackishContext _context;          
        }
    }
}

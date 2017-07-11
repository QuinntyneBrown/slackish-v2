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
        public class GetClaimsForUserRequest : IRequest<GetClaimsForUserResponse>
        {
            public string Username { get; set; }
        }

        public class GetClaimsForUserResponse
        {
            public ICollection<Claim> Claims { get; set; }
        }

        public class GetClaimsForUserHandler : IAsyncRequestHandler<GetClaimsForUserRequest, GetClaimsForUserResponse>
        {
            public GetClaimsForUserHandler(SlackishContext context)
            {
                _context = context;
            }

            public async Task<GetClaimsForUserResponse> Handle(GetClaimsForUserRequest message)
            {

                var claims = new List<System.Security.Claims.Claim>();

                var user = await _context.Users                    
                    .SingleAsync(x => x.Username == message.Username);

                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", message.Username));

                claims.Add(new Claim("tenant-id", $"{user.TenantId}"));

                return new GetClaimsForUserResponse()
                {
                    Claims = claims
                };
            }

            private readonly SlackishContext _context;          
        }
    }
}

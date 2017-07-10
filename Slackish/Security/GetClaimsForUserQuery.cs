//using MediatR;
//using Slackish.Data;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using System.Data.Entity;
//using System.Security.Claims;

//namespace Slackish.Security
//{
//    public class GetClaimsForUserQuery
//    {
//        public class GetClaimsForUserRequest : IRequest<GetClaimsForUserResponse>
//        {
//            public string Username { get; set; }
//        }

//        public class GetClaimsForUserResponse
//        {
//            public ICollection<Claim> Claims { get; set; }
//        }

//        public class GetClaimsForUserHandler : IAsyncRequestHandler<GetClaimsForUserRequest, GetClaimsForUserResponse>
//        {
//            public GetClaimsForUserHandler(SlackishDbContext context)
//            {
//                _context = context;
//            }

//            public async Task<GetClaimsForUserResponse> Handle(GetClaimsForUserRequest message)
//            {

//                var claims = new List<System.Security.Claims.Claim>();

//                var user = await _context.Users
//                    .Include(x => x.Roles)
//                    .SingleAsync(x => x.Username == message.Username);

//                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", message.Username));

//                foreach (var role in user.Roles.Select(x => x.Name))
//                {
//                    claims.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role));
//                }

//                return new GetClaimsForUserResponse()
//                {
//                    Claims = claims
//                };
//            }

//            private readonly SlackishDbContext _context;
            
//        }
//    }
//}

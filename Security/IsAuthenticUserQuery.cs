using MediatR;
using Slackish.Data;
using Slackish.Data.Model;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Slackish.Security
{
    public class IsAuthenticUserQuery
    {
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string TeamName { get; set; }
        }

        public class Response
        {
            public Response()
            {

            }

            public bool IsAuthenticated { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext context, IEncryptionService encryptionService)
            {
                _encryptionService = encryptionService;
                _context = context;
            }

            public bool ValidateUser(User user, string transformedPassword)
            {
                if (user == null || transformedPassword == null)
                    return false;
                return user.Password == transformedPassword;
            }

            public async Task<Response> Handle(Request request)
            {
                var user = await _context.Users
                    .Include(x => x.TeamUsers) 
                    .Include("TeamUsers.Team")
                    .SingleOrDefaultAsync(x => x.Username.ToLower() == request.Username.ToLower() && !x.IsDeleted);

                return new Response()
                {
                    IsAuthenticated = ValidateUser(user, _encryptionService.TransformPassword(request.Password)) && user.TeamUsers.Any(x => x.Team.Name == request.TeamName)
                };
            }

            private readonly SlackishContext _context;
            private readonly IEncryptionService _encryptionService;

        }
    }
}

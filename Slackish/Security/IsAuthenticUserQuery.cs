using MediatR;
using Slackish.Data;
using Slackish.Data.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Slackish.Security
{
    public class IsAuthenticUserQuery
    {
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public Response()
            {

            }

            public bool IsAuthenticated { get; set; }
        }

        public class IsAuthenticUserHandler : IAsyncRequestHandler<Request, Response>
        {
            public IsAuthenticUserHandler(SlackishContext context, IEncryptionService encryptionService)
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

            public async Task<Response> Handle(Request message)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Username.ToLower() == message.Username.ToLower() && !x.IsDeleted);
                return new Response()
                {
                    IsAuthenticated = ValidateUser(user, _encryptionService.TransformPassword(message.Password))
                };
            }

            private readonly SlackishContext _context;
            private readonly IEncryptionService _encryptionService;

        }

    }

}

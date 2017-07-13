using MediatR;
using Slackish.Data;
using Slackish.Data.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Slackish.Security
{
    public class IsValidUserQuery
    {
        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public bool IsAuthenticated { get; set; }
        }

        public class IsValidUserHandler : IAsyncRequestHandler<Request, Response>
        {
            public IsValidUserHandler(SlackishContext context, IEncryptionService encryptionService)
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
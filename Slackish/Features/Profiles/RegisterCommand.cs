using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Data.Entity;
using Slackish.Data.Models;
using Slackish.Security;

namespace Slackish.Features.Profiles
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterResponse { }

    public class RegisterCommand: IAsyncRequestHandler<RegisterRequest,RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterRequest request)
        {
            var profile = await _context
                .Profiles
                .Include(x => x.User)
                .Where(x => x.User.Username == request.Username)
                .SingleOrDefaultAsync();

            if (profile != null)
                throw new InvalidOperationException();

            var user = new User()
            {
                Username = request.Username,
                Password = _encryptionService.TransformPassword(request.Password)
            };  

            _context.Profiles.Add(new Profile()
            {
                User = user
            });

            await _context.SaveChangesAsync();

            return new RegisterResponse();
        }

        private SlackishContext _context { get; set; }
        private IEncryptionService _encryptionService { get; set; }        
    }
}

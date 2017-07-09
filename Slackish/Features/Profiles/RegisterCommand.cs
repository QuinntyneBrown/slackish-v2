using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Data.Entity;
using Slackish.Data.Models;
using Slackish.Features.Core;
using Slackish.Security;

namespace Slackish.Features.Profiles
{
    public class RegisterRequest: IAsyncRequest<RegisterResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterResponse
    {

    }

    public class RegisterCommand: IAsyncRequestHandler<RegisterRequest,RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterRequest message)
        {
            var profile = await _slackishDbContext
                .Profiles
                .Include(x=>x.User)
                .Where(x => x.User.Username == message.Username)
                .SingleOrDefaultAsync();

            if (profile != null)
                throw new InvalidOperationException();

            var user = new User()
            {
                Username = message.Username,
                Password = _encryptionService.TransformPassword(message.Password)
            };  

            _slackishDbContext.Profiles.Add(new Profile()
            {
                User = user
            });

            await _slackishDbContext.SaveChangesAsync();

            return new RegisterResponse();

        }

        private SlackishDbContext _slackishDbContext { get; set; }
        private IEncryptionService _encryptionService { get; set; }
                
    }
}

using MediatR;
using Slackish.Data;
using Slackish.Data.Models;
using Slackish.Security;
using System;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Profiles
{
    public class RegisterCommand
    {
        public class Request : IRequest
        {
            public Guid TenantUniqueId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }
        
        public class Handler : IRequestHandler<Request>
        {
            public Handler(SlackishContext context, IEncryptionService encryptionService)
            {
                _context = context;
                _encryptionService = encryptionService;
            }

            public void Handle(Request request)
            {
                var profile = _context
                    .Profiles
                    .Include(x => x.User)
                    .Where(x => x.User.Username == request.Username)
                    .SingleOrDefault();

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

                _context.SaveChanges();
            }

            private readonly SlackishContext _context;
            private readonly IEncryptionService _encryptionService;
        }

    }

}

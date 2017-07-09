using System.Threading.Tasks;
using System.Security.Principal;
using Slackish.Data;
using System.Data.Entity;
using Slackish.Data.Models;

namespace Slackish.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(SlackishDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly SlackishDbContext _context;
    }
}

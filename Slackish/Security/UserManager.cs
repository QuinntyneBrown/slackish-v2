using Slackish.Data;
using Slackish.Data.Models;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Data.Entity;

namespace Slackish.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(SlackishContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context.Users.SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly SlackishContext _context;
    }
}

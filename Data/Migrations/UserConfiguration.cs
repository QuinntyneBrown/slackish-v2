using Slackish.Data;
using Slackish.Data.Model;
using Slackish.Security;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(SlackishContext context)
        {
            var tenant = context.Tenants.Single(x => x.Name == "Default");
            var user = context.Users
                .Include(x => x.TeamUsers)
                .Include("TeamUsers.Team")
                .SingleOrDefault();

            if (user == null) {
                user = new User();
                context.Users.Add(user);
            }

            user.TeamUsers.Clear();

            user.Username = "system";
            user.Password = new EncryptionService().TransformPassword("system");
            user.TenantId = tenant.Id;

            var team = context.Teams.Include(x => x.TeamUsers).Single(x => x.Name == "My Team");
            
            user.TeamUsers.Add(new TeamUser() { TeamId = team.Id });
            user.CurrentTeam = team;

            context.SaveChanges();
        }
    }
}
using Slackish.Data;
using Slackish.Data.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Slackish.Migrations
{
    public class ProfileConfiguration
    {
        public static void Seed(SlackishContext context) {

            var tenant = context.Tenants.Single(x => x.Name == "Default");
            var user = context.Users.Single(x => x.Username == "system");

            context.Profiles.AddOrUpdate(x => x.Name, new Profile()
            {
                Name = "system",
                UserId = user.Id,
                TenantId = tenant.Id
            });

            context.SaveChanges();
        }
    }
}

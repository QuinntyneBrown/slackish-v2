using System.Data.Entity.Migrations;
using System.Linq;
using Slackish.Data.Model;

namespace Slackish.Data.Migrations
{
    public class TeamConfiguration
    {
        public static void Seed(SlackishContext context) {

            var tenant = context.Tenants.Single(x => x.Name == "Default");

            context.Teams.AddOrUpdate(x=>x.Name, new Team() {
                TenantId = tenant.Id,
                Name = "My Team"
            });

            context.SaveChanges();
        }
    }
}

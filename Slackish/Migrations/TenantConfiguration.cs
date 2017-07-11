using System.Data.Entity.Migrations;
using Slackish.Data;

namespace Slackish.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(SlackishContext context) {

            context.SaveChanges();
        }
    }
}

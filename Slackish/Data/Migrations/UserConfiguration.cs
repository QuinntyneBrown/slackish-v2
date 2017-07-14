using Slackish.Data;
using Slackish.Data.Model;
using Slackish.Security;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Slackish.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(SlackishContext context)
        {
            var tenant = context.Tenants.Single(x => x.Name == "Default");
            
            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = "system",
                Password = new EncryptionService().TransformPassword("system"),
                TenantId = tenant.Id
            });

            context.SaveChanges();
        }
    }
}
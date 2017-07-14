using System.Data.Entity.Migrations;
using Slackish.Data;
using Slackish.Data.Model;
using System;

namespace Slackish.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(SlackishContext context) {
            
            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default",
                UniqueId = new Guid("cff89028-3e2d-4997-ab12-a07e0d50ba90")
            });
            
            context.SaveChanges();
        }
    }
}

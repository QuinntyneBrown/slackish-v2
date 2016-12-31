using System.Data.Entity.Migrations;
using Slackish.Data;
using Slackish.Models;
using Slackish.Services;

namespace Slackish.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(DataContext context) {

            context.SaveChanges();
        }
    }
}

using System.Data.Entity.Migrations;
using Slackish.Data;
using Slackish.Utilities;

namespace Slackish.Migrations
{
    public class ProfileConfiguration
    {
        public static void Seed(DataContext context) {

            context.SaveChanges();
        }
    }
}

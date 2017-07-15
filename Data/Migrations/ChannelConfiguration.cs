using System.Data.Entity.Migrations;
using Slackish.Data;

namespace Slackish.Data.Migrations
{
    public class ChannelConfiguration
    {
        public static void Seed(SlackishContext context) {

            context.SaveChanges();
        }
    }
}

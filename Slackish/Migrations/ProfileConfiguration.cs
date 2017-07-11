using Slackish.Data;

namespace Slackish.Migrations
{
    public class ProfileConfiguration
    {
        public static void Seed(SlackishContext context) {

            context.SaveChanges();
        }
    }
}

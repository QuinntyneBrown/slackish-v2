namespace Slackish.Migrations
{
    using Data.Migrations;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Slackish.Data.SlackishContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Slackish.Data.SlackishContext context)
        {
            TenantConfiguration.Seed(context);
            TeamConfiguration.Seed(context);
            ChannelConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            ProfileConfiguration.Seed(context);
        }
    }
}

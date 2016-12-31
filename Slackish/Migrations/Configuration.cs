namespace Slackish.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Slackish.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Slackish.Data.DataContext context)
        {
            TenantConfiguration.Seed(context);
            ProfileConfiguration.Seed(context);
        }
    }
}

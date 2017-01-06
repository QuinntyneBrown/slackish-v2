using Slackish.Data.Models;
using System.Data.Entity;

namespace Slackish.Data
{
    public class SlackishDbContext: DbContext
    {
        public SlackishDbContext()
            : base(nameOrConnectionString: "SlackishDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}

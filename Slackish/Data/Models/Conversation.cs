using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}

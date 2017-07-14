using Slackish.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Conversation: ILoggable
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

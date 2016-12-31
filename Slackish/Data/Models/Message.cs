using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int ConversationId { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
    }
}

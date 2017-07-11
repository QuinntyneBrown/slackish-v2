using Slackish.Data.Helpers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Models
{
    [SoftDelete("IsDeleted")]
    public class Tenant: ILoggable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Index("UniqueIdIndex", IsUnique = false)]
        [Column(TypeName = "UNIQUEIDENTIFIER")]
        public Guid UniqueId { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
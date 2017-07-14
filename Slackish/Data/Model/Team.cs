using System;
using Slackish.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Slackish.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class Team: ILoggable
    {
        public int Id { get; set; }
        
		[ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        
		[Index("TeamNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]     
        [StringLength(255)]		   
		public string Name { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; } = new HashSet<TeamUser>();        
        public DateTime CreatedOn { get; set; }
        
		public DateTime LastModifiedOn { get; set; }
        
		public string CreatedBy { get; set; }
        
		public string LastModifiedBy { get; set; }
        
		public bool IsDeleted { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}

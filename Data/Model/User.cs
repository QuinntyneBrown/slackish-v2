using Slackish.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class User:ILoggable
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Index("UserNameIndex", IsUnique = false)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get { return $"{Firstname} {Lastname}"; } }
        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<TeamUser> TeamUsers { get; set; } = new HashSet<TeamUser>();
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}

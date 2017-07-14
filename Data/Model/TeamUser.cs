using System.ComponentModel.DataAnnotations.Schema;

namespace Slackish.Data.Model
{
    public class TeamUser
    {
        public int? Id { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
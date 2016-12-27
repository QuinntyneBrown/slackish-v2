using System.Collections.Generic;

namespace Slackish.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Conversation> Conversations { get; set; } = new HashSet<Conversation>();
        public bool IsDeleted { get; set; }
    }
}

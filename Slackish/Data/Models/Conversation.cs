using System.Collections.Generic;

namespace Slackish.Data.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}

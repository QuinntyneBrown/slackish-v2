namespace Slackish.Data.Models
{
    public class Message
    {

        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int ConversationId { get; set; }
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
    }
}

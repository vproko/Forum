using System;

namespace Forum.Dto.Models
{
    public class MessageDto
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public string SenderUsername { get; set; }

        public UserDto User { get; set; }
    }
}

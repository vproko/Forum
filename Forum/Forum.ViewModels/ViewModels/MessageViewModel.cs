using System;

namespace Forum.ViewModels.ViewModels
{
    public class MessageViewModel
    {
        public string MessageID { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverUsername { get; set; }
        public string SenderID { get; set; }
        public string SenderUsername { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}

using Forum.ViewModels.ViewModels;

namespace Forum.WebApp.Models
{
    public class ReportsPageInfoModel
    {
        public UserViewModel Admin { get; set; }
        public int PostIdx { get; set; }
        public int ReplyIdx { get; set; }
        public int PostPgSize { get; set; }
        public int ReplyPgSize { get; set; }
        public string WhichTab { get; set; }
    }
}

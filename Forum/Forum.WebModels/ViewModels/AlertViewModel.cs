using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.WebModels.ViewModels
{
    public class AlertViewModel
    {
        public string AlertID { get; set; }
        public string PostID { get; set; }
        public string UserID { get; set; }
        public UserViewModel User { get; set; }
        public PostViewModel Post { get; set; }
    }
}

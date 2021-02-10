using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.VMs
{
    public class TimeLineVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string UserProfilePicture { get; set; }
        public DateTime CreateDate { get; set; }

        public int MentionCount { get; set; }
        public int ShareCount { get; set; }
        public int LikeCount { get; set; }
        public bool isLiked { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class LikeDTO
    {
        public int AppUserId { get; set; }
        public int TweetId { get; set; }
        public bool isExsist { get; set; }
    }
}

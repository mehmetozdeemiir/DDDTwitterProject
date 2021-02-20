using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class AddMentionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AppUserId { get; set; }
        public int TweetId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

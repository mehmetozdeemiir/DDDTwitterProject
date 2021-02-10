using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class FollowDTO
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public bool isExsist { get; set; }

    }
}

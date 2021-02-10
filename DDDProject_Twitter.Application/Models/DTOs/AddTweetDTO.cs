using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class AddTweetDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int AppUserId { get; set; }
        public IFormFile Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string ImagePath { get => "/images/users/default.jpg"; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}

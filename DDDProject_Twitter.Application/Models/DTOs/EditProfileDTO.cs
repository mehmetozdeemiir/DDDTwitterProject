using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDDProject_Twitter.Application.Models.DTOs
{
    public class EditProfileDTO
    {
        //Business Domain ihtiyaçlarımıza göre hazırladığımız veri transfer objelerimiz ef öğrenmeye başladğımız ilk günden beri kulllanıdıgımız attribute bazında şartlar içerebilirler.Eski projelerimizde örneğin CMS projesinde bir prototype hem entity hemde DTO gibi kullanyorduk. 
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to type into name")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}

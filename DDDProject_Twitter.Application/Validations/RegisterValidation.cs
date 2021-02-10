using DDDProject_Twitter.Application.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Validations
{
    public class RegisterValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Enter e mail address").EmailAddress().WithMessage("Please type into a valid email address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Pleasee enter a password");
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Password do not macth");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty.").MinimumLength(3).MaximumLength(20).WithMessage("Minimum 3, maximum 20 character");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name can't be empty").MinimumLength(3).MaximumLength(20).WithMessage("Minimum 3, maxsimum 20 character");
        }
    }
}

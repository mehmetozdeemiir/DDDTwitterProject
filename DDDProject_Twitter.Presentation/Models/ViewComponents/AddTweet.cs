using DDDProject_Twitter.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Models.ViewComponents
{
    public class AddTweet : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userId = Convert.ToInt32(claim.Value);
            var tweet = new AddTweetDTO();
            tweet.AppUserId = userId;
            return View(tweet);
        }
    }
}

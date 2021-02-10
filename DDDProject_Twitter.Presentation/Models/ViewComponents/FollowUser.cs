using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Models.ViewComponents
{
    public class FollowUser:ViewComponent
    {
        private readonly IAppUserService _userService;
        private readonly IFollowService _followService;

        public FollowUser(IAppUserService appUserService,
                          IFollowService followService)
        {
            this._userService = appUserService;
            this._followService = followService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string userName)
        {
            int userId = await _userService.GetUserIdFromName(userName);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int followerId = Convert.ToInt32(claim.Value);

            var followModel = new FollowDTO { FollowerId = followerId, FollowingId = userId };
            followModel.isExsist = await _followService.IsFollowing(followModel);
            return View(followModel);
        }
    }
}

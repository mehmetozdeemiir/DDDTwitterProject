using DDDProject_Twitter.Application.Extensions;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Controllers
{
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;
        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Follow(FollowDTO model)
        {
            if (!model.isExsist)//modelde veri yoksa
            {
                if (model.FollowerId == User.GetUserId())
                {
                    await _followService.Follow(model);
                    return Json("Success");
                }
                else return Json("Faild");
            }
            else
            {
                if (model.FollowerId == User.GetUserId())
                {
                    await _followService.UnFollow(model);
                    return Json("Success");
                }
                else return Json("Faild");
            }

        }
    }
}

using DDDProject_Twitter.Application.Extensions;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Controllers
{
    public class TweetController : Controller
    {
        private readonly ITweetService _tweetService;

        public TweetController(ITweetService tweetService)
        {
            this._tweetService = tweetService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> AddTweet(AddTweetDTO addTweetDTO)
        {
            if (ModelState.IsValid)
            {
                if (addTweetDTO.AppUserId == User.GetUserId())
                {
                    await _tweetService.AddTweet(addTweetDTO);
                    return Json("Success");
                }
                else return Json("Faild");

            }
            else return BadRequest(String.Join(Environment.NewLine, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage + " " + x.Exception)));
        }
        [HttpPost]
        public async Task<IActionResult> GetTweets(int pageIndex,int pageSize,string userName)
        {
            if (userName==null)
            {
                return Json(await _tweetService.GetTimeLine(User.GetUserId(), pageIndex), new JsonSerializerSettings());
            }
            else
            {
                return Json(await _tweetService.UserTweets(userName, pageIndex));
            }
            
        }
    }
}

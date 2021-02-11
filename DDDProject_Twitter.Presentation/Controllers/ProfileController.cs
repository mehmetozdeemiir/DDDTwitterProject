using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAppUserService _appUserService;
        public ProfileController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string userName)
        {
            //ViewBag, Controller'da oluşturulan bir yapıyı View kısmına taşımak için kullanılır. Kendi içerisinde birden fazla yapının aktarılmasına olanak sunmaktadır. İçerisine bir string ifade, integer ifade yada list gönderebilmek ya da eşitleyebilmek mümkündür.
            ViewBag.userName = userName;
            return View();
        }     
        public IActionResult Followings(string userName)
        {
            ViewBag.userName = userName;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Followings(string userName,int pageIndex)
        {
            var findUser = await _appUserService.GetUserIdFromName(userName);
            if (findUser>0)//kullanıcı id var ise
            {
                var followings = await _appUserService.UsersFollowings(findUser, pageIndex);
                return Json(followings, new JsonSerializerSettings());
            }
            else
            {
                return NotFound();
            }
        }
       
        
        public IActionResult Followers(string userName)
        {
            ViewBag.userName = userName;
            return View();
        }
        
        
        [HttpPost]
        public async Task<IActionResult>Followers(string userName,int pageIndex)
        {
            var findUser = await _appUserService.GetUserIdFromName(userName);
            if (findUser>0)
            {
                var followers = await _appUserService.UsersFollowers(findUser, pageIndex);
                return Json(followers, new JsonSerializerSettings());
            }
            else
            {
                return NotFound();
            }
        }
    }

}

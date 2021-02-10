using DDDProject_Twitter.Application.Extensions;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;
        public AccountController(IAppUserService appUserService)
        {
            _userService = appUserService;
        }


        public IActionResult Register()
        {
            //IsAuthenticated=>Kullanıcı kimliğini kontrol ediyo doğruluyor
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)//Daha önce koyduğumuz kurallara uyduysa gerçekleştir.
            {
                var result = await _userService.Register(registerDTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }
            return View(registerDTO);
        }


        public IActionResult Login(string returnUrl = null)
        {
            //IsAuthenticated=>Benim kullanıcı haricinde başka bişey olup olmadığımı kontrol ediyo kullanıcıysam sayfaya gönderiyor.
            if (User.Identity.IsAuthenticated) return RedirectToAction(nameof(HomeController.Index), "Home");

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LogIn(model);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(String.Empty, "Invalid login attempt..!");
            }
            return View();
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);//?
            else return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOut();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> EditProfile(string userName)
        {
            if (userName == User.Identity.Name)
            {
                var user = await _userService.GetById(User.GetUserId());
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileDTO model, IFormFile file)
        {
            //model.Image = file;
            await _userService.EditUser(model);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }

}


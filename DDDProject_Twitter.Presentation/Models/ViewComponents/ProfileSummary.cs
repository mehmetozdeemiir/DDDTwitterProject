using DDDProject_Twitter.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Presentation.Models.ViewComponents
{
    public class ProfileSummary : ViewComponent
    {
        private readonly IAppUserService _appUserService;

        public ProfileSummary(IAppUserService appUserService) => this._appUserService = appUserService;

        public async Task<IViewComponentResult> InvokeAsync(string userName) => View(await _appUserService.GetByUserName(userName));
    }
}

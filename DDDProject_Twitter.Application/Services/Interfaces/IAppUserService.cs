using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Models.VMs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Interfaces
{
    public interface IAppUserService
    {
        Task DeleteUser(params object[] parameters);

        Task<IdentityResult> Register(RegisterDTO registerDTO);

        Task<SignInResult> LogIn(LoginDTO loginDTO);

        Task LogOut();

        Task<int> GetUserIdFromName(string name);

        Task<EditProfileDTO> GetById(int id);

        Task EditUser(EditProfileDTO editProfileDTO);

        Task<ProfileSummaryDTO> GetByUserName(string userName);

        //hazırladığımız vm i burda liste çekicez
        Task<List<FollowListVM>> UsersFollowers(int id, int pageIndex); //pageındex gonderıyorum kı sayfalama yaparken yardımcı olucak.
        Task<List<FollowListVM>> UsersFollowings(int id, int pageIndex);

    }
}

using AutoMapper;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Models.VMs;
using DDDProject_Twitter.Application.Services.Interfaces;
using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Concrete
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFollowService _followService;

        public AppUserService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              IFollowService followService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._followService = followService;
        }

        public async Task DeleteUser(params object[] parameters) => await _unitOfWork.ExecuteSqlRaw("spDeleteUsers {0}", parameters);

        public async Task EditUser(EditProfileDTO editProfileDTO)
        {
            AppUser user = await _unitOfWork.AppUserRepository.GetById(editProfileDTO.Id);

            if (user != null)
            {
                if (editProfileDTO.Image != null)
                {
                    using var image = Image.Load(editProfileDTO.Image.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save("wwwroot/images/users/" + Guid.NewGuid().ToString() + ".jpg");
                    user.ImagePath = ("/images/users/" + Guid.NewGuid().ToString() + ".jpg");
                }

                if (editProfileDTO.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, editProfileDTO.Password);
                    await _userManager.UpdateAsync(user);
                }

                if (editProfileDTO.UserName != null)
                {
                    var isUserNameExsist = _userManager.FindByNameAsync(editProfileDTO.UserName);
                    if (isUserNameExsist == null)
                    {
                        await _userManager.SetUserNameAsync(user, editProfileDTO.UserName);
                        //user.UserName = editProfileDTO.UserName;
                        //await _userManager.UpdateAsync(user);
                    }
                }

                if (editProfileDTO.Email != null)
                {
                    var isEmailExsist = _userManager.FindByEmailAsync(editProfileDTO.Email);
                    if (isEmailExsist == null) await _userManager.SetEmailAsync(user, editProfileDTO.Email);
                }

                if (editProfileDTO.Name != null)
                {
                    user.Name = editProfileDTO.Name;
                }

                _unitOfWork.AppUserRepository.Update(user);
                await _unitOfWork.Commit();
            }
        }

        public async Task<EditProfileDTO> GetById(int id)
        {
            AppUser user = await _unitOfWork.AppUserRepository.GetById(id);

            return _mapper.Map<EditProfileDTO>(user);
        }

        public async Task<ProfileSummaryDTO> GetByUserName(string userName)
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => new ProfileSummaryDTO
                {
                    UserName = x.UserName,
                    Name = x.Name,
                    ImagePath = x.ImagePath,
                    TweetCount = x.Tweets.Count,
                    FollowerCount = x.Followers.Count,
                    FollowingCount = x.Followings.Count,
                },
                expression: x => x.UserName == userName);

            return user;
        }

        public async Task<int> GetUserIdFromName(string name)//isminden Id getir
        {
            var user = await _unitOfWork.AppUserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id,
                expression: x => x.Name == name);

            return user;
        }

        public async Task<SignInResult> LogIn(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);//ilk false çerezler şifreni hatırlasın mı? ikinci false başarısızzlık durumunda kitlemek.

            return result;
        }

        public async Task LogOut() => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<AppUser>(registerDTO);//RegisterDTO?

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded) await _signInManager.SignInAsync(user, isPersistent: false);
            return result;
        }


        public async Task<List<FollowListVM>> UsersFollowers(int id, int pageIndex)
        {
            List<int> followers = await _followService.Followers(id);

            var followersList = await _unitOfWork.AppUserRepository.GetFilteredList(
                selector: x => new FollowListVM
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    UserName = x.UserName,
                    Name = x.Name
                },
                expression: x => followers.Contains(x.Id),
                include: x => x.Include(x => x.Followers),
                pageIndex: pageIndex);

            return followersList;
        }

        public async Task<List<FollowListVM>> UsersFollowings(int id, int pageIndex)
        {
            List<int> followings = await _followService.Followings(id);

            var followingsList = await _unitOfWork.AppUserRepository.GetFilteredList(
                selector: x => new FollowListVM
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    UserName = x.UserName,
                    Name = x.Name
                },
                expression: x => followings.Contains(x.Id),
                include: x => x.Include(x => x.Followings),
                pageIndex: pageIndex);

            return followingsList;
        }
    }
}

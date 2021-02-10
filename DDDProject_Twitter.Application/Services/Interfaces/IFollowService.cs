using DDDProject_Twitter.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Interfaces
{
    public interface IFollowService
    {
        Task Follow(FollowDTO followDTO);

        Task UnFollow(FollowDTO followDTO);

        Task<bool> IsFollowing(FollowDTO followDTO); //takip ediyor mu?

        Task<List<int>> Followers(int id);

        Task<List<int>> Followings(int id);
    }
}

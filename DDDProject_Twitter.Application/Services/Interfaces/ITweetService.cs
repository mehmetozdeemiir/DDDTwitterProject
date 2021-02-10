using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Interfaces
{
    public interface ITweetService
    {
        Task<List<TimeLineVM>> GetTimeLine(int userId, int pageIndex);
        Task AddTweet(AddTweetDTO addTweetDTO);
        Task<List<TimeLineVM>> UserTweets(string userName, int pageIndex);
        Task DeleteTweet(int id, int userId);
    }
}

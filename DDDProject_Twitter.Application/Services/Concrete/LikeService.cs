using AutoMapper;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Interfaces;
using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikeService(UnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task Like(LikeDTO likeDTO)
        {
            var isLiked = await _unitOfWork.LikeRepository.FirstOrDefault(x => x.AppUserId == likeDTO.AppUserId && x.TweetId == likeDTO.TweetId);//DTO dan gelen ile veritabanınadakı birbirine denk mi
            if (isLiked == null)
            {
                var like = _mapper.Map<LikeDTO, Like>(likeDTO);
                await _unitOfWork.LikeRepository.Add(like);
                await _unitOfWork.Commit();
            }
        }

        public async Task UnLike(LikeDTO likeDTO)
        {
            var isLiked = await _unitOfWork.LikeRepository.FirstOrDefault(x => x.AppUserId == likeDTO.AppUserId && x.TweetId == likeDTO.TweetId);
            _unitOfWork.LikeRepository.Delete(isLiked);
            await _unitOfWork.Commit();
        }
    }
}

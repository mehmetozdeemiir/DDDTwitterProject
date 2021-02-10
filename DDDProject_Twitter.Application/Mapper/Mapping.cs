using AutoMapper;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, EditProfileDTO>().ReverseMap();
            CreateMap<AppUser, ProfileSummaryDTO>().ReverseMap();

            CreateMap<Follow, FollowDTO>().ReverseMap();
            CreateMap<Like, LikeDTO>().ReverseMap();

            CreateMap<Mention, AddMentionDTO>().ReverseMap();
        }
    }
}

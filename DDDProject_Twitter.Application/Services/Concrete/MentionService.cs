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
    public class MentionService : IMentionService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MentionService(UnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task AddMention(AddMentionDTO addMentionDTO)
        {
            var mention = _mapper.Map<AddMentionDTO, Mention>(addMentionDTO);
            await _unitOfWork.MentionRepository.Add(mention);
            await _unitOfWork.Commit();
        }
    }
}

using DDDProject_Twitter.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Application.Services.Interfaces
{
     public interface IMentionService
    {
        Task AddMention(AddMentionDTO addMentionDTO);
    }
}

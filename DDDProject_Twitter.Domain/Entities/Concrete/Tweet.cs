using DDDProject_Twitter.Domain.Entities.Interface;
using DDDProject_Twitter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Domain.Entities.Concrete
{
    public class Tweet : IBase<int>, IBaseEntity
    {
        public int Id { get ; set ; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Like> Likes { get; set; }
        public List<Mention> Mentions { get; set; }
        public List<Share> Shares { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}

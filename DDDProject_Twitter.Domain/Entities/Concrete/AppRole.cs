using DDDProject_Twitter.Domain.Entities.Interface;
using DDDProject_Twitter.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Domain.Entities.Concrete
{
    public class AppRole : IdentityRole<int>, IBaseEntity
    {
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}

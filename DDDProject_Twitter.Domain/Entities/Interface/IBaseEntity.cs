using DDDProject_Twitter.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Domain.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        Status Status { get; set; }
    }
}

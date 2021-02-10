using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Domain.Entities.Interface
{
    public interface IBase<T>
    {
        T Id { get; set; }
    }
}

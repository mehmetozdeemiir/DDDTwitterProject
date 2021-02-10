using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{
     public class AppRoleMap:BaseMap<AppRole>
    {
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
        }
    }
}

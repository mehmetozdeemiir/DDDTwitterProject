using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{
    public class FollowMap:BaseMap<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(x => new { x.FollowerId, x.FollowingId });

            base.Configure(builder);
        }
    }
}

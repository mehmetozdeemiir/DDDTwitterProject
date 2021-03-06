﻿using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{
    public class LikeMap : BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {

            builder.HasKey(x => new { x.AppUserId, x.TweetId });

            base.Configure(builder);
        }
    }
}

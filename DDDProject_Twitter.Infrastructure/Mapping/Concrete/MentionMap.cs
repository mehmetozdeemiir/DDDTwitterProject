using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{
    public class MentionMap : BaseMap<Mention>
    {
        public override void Configure(EntityTypeBuilder<Mention> builder)
        {
            builder.HasKey(x => new { x.Id, x.AppUserId, x.TweetId });
            builder.Property(x => x.Text).IsRequired(false);


            base.Configure(builder);
        }
    }
}

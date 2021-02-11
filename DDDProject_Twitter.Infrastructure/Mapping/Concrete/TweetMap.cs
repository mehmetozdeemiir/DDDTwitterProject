using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{

    public class TweetMap : BaseMap<Tweet>
    {
        public override void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.HasMany(x => x.Mentions).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Likes).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Shares).WithOne(x => x.Tweet).HasForeignKey(x => x.TweetId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Tweets).HasForeignKey(x => x.AppUserId);


            base.Configure(builder);
        }
    }
}

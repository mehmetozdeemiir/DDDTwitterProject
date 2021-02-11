using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Infrastructure.Mapping.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Concrete
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            //Identity ile gelen property'leride mapping edebiliriz
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.NormalizedUserName).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ImagePath).HasMaxLength(50).IsRequired(true);


            builder.HasMany(x => x.Tweets).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Mentions).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Likes).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Shares).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Followers).WithOne(x => x.Follower).HasForeignKey(x => x.FollowerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Followings).WithOne(x => x.Following).HasForeignKey(x => x.FollowingId).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);

        }
    }
}

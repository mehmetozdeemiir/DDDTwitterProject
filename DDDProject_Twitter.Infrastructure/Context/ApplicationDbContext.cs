using DDDProject_Twitter.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Context
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Follow> AppUsers { get; set; }
        public DbSet<Follow> AppRoles { get; set; }

    }

     

    
}

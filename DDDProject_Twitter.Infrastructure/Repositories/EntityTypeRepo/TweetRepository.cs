using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Domain.Repositories.EntityTypeRepo;
using DDDProject_Twitter.Infrastructure.Context;
using DDDProject_Twitter.Infrastructure.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Repositories.EntityTypeRepo
{
    public class TweetRepository : BaseRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

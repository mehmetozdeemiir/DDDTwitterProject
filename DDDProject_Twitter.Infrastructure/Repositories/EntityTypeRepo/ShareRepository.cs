using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Domain.Repositories.EntityTypeRepo;
using DDDProject_Twitter.Infrastructure.Context;
using DDDProject_Twitter.Infrastructure.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Repositories.EntityTypeRepo
{
    public class ShareRepository : BaseRepository<Share>, IShareRepository
    {
        public ShareRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

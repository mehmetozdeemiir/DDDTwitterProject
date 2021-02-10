using DDDProject_Twitter.Domain.Entities.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Infrastructure.Mapping.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.UpdateDate).IsRequired(false);//nullable olanlar boş geçilebilir yani false.
            builder.Property(x => x.DeleteDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}

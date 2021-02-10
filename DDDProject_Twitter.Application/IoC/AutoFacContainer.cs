using Autofac;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Concrete;
using DDDProject_Twitter.Application.Services.Interfaces;
using DDDProject_Twitter.Application.Validations;
using DDDProject_Twitter.Domain.UnitOfWork;
using DDDProject_Twitter.Infrastructure.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.IoC
{
   public class AutoFacContainer:Module
    {
       protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<FollowService>().As<IFollowService>().InstancePerLifetimeScope();
            builder.RegisterType<LikeService>().As<ILikeService>().InstancePerLifetimeScope();
            builder.RegisterType<TweetService>().As<ITweetService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
     

            builder.RegisterType<LoginValidation>().As<IValidator<LoginDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<TweetValidation>().As<IValidator<AddTweetDTO>>().InstancePerLifetimeScope();
        }
    }
}

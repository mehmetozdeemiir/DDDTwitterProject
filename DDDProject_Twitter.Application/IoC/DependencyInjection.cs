using DDDProject_Twitter.Application.Mapper;
using DDDProject_Twitter.Application.Models.DTOs;
using DDDProject_Twitter.Application.Services.Concrete;
using DDDProject_Twitter.Application.Services.Interfaces;
using DDDProject_Twitter.Application.Validations;
using DDDProject_Twitter.Domain.Entities.Concrete;
using DDDProject_Twitter.Domain.UnitOfWork;
using DDDProject_Twitter.Infrastructure.Context;
using DDDProject_Twitter.Infrastructure.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDProject_Twitter.Application.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //registration
            services.AddAutoMapper(typeof(Mapping));

            //reseolve
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMentionService, MentionService>();
            services.AddScoped<ITweetService, TweetService>();

            //Validation Resolver
            services.AddTransient<IValidator<RegisterDTO>, RegisterValidation>();
            services.AddTransient<IValidator<LoginDTO>, LoginValidation>();
            services.AddTransient<IValidator<AddTweetDTO>, TweetValidation>();

            //"AddIdentity" sınıfı için Microsoft.AspNetCore.Identity paketi indirilir.
            services.AddIdentity<AppUser, AppRole>(x => {
                x.SignIn.RequireConfirmedAccount = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.User.RequireUniqueEmail = false;
                x.Password.RequiredLength = 3;
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            return services; //burası iptal autofac yaptık zaten
        }
    }
}

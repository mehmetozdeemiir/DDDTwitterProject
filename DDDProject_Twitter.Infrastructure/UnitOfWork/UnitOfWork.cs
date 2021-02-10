using DDDProject_Twitter.Domain.Repositories.EntityTypeRepo;
using DDDProject_Twitter.Domain.UnitOfWork;
using DDDProject_Twitter.Infrastructure.Context;
using DDDProject_Twitter.Infrastructure.Repositories.EntityTypeRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) => this._db = db ?? throw new ArgumentNullException("database can not to be null") { };//?? ya bana db yi dönücek yada... if else gibi


        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUserRepository
        {
            get { return _appUserRepository ?? (_appUserRepository = new AppUserRepository(_db)); }
        }

        private IFollowRepository _followRepository;
        public IFollowRepository FollowRepository { get => _followRepository ?? (_followRepository = new FollowRepository(_db)); }

        private ILikeRepository _likeRepository;
        public ILikeRepository LikeRepository { get => _likeRepository ?? (_likeRepository = new LikeRepository(_db)); }

        private IMentionRepository _mentionRepository;
        public IMentionRepository MentionRepository { get => _mentionRepository ?? (_mentionRepository = new MentionRepository(_db)); }

        private IShareRepository _shareRepository;
        public IShareRepository ShareRepository { get => _shareRepository ?? (_shareRepository = new ShareRepository(_db)); }

        private ITweetRepository _tweetRepository;
        public ITweetRepository TweetRepository { get => _tweetRepository ?? (_tweetRepository = new TweetRepository(_db)); }

        public async Task Commit() => await _db.SaveChangesAsync();

        public async Task ExecuteSqlRaw(string sql, params object[] paramters) => await _db.Database.ExecuteSqlRawAsync(sql, paramters);

        private bool isDisposing = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);//unit of work nesnemizi tamamen kaldırdık nesnenin temizlenmesini sağlıycak.
            }
        }

        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync();
        }
    }
}

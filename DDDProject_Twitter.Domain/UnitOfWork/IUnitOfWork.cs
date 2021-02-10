using DDDProject_Twitter.Domain.Repositories.EntityTypeRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Domain.UnitOfWork
{
  
        public interface IUnitOfWork
        {
            IAppUserRepository AppUserRepository { get; }
            IFollowRepository FollowRepository { get; }
            ILikeRepository LikeRepository { get; }
            IMentionRepository MentionRepository { get; }
            IShareRepository ShareRepository { get; }
            ITweetRepository TweetRepository { get; }

            Task Commit();//başarılı bir şekilde işlemler gerçekleşmişse çalıştırılır.İşlemin başlamasından itibaren tüm değişikliklerin veri tabanına uygulanmasını temin eder. savechange bunun içinde olucak.

            Task ExecuteSqlRaw(string sql, params object[] paramters);//Mevcut sql sorgularımızı doğrudan veritabanında yürtmek için kullanılan methoddur.
        }

     
    }

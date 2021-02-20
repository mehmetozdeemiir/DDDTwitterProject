using DDDProject_Twitter.Domain.Repositories.EntityTypeRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDDProject_Twitter.Domain.UnitOfWork
{
  //“Nasıl olsa garbage collector bu işi yapıyor ben neden uğraşayım.” diye düşünsek de bazı durumlar da bu yapıyı bizim çalıştırmamız uygulamanın performansı açısından önem arz eder. Garbage collector u kendimiz çağırabilmemiz için öncelikle kullanacağımız classa “IDisposable” interface ini miras vermemiz ve sonrasında da implemente etmemiz gerekmektedir.Implemente işleminden sonra classımızın içine void bir method olan “Dispose” metodu gelecektir. Ram üzerinden hemen silmek istediğimiz verileri ve işlemleri bu metodun içine yazarak garbage collector un silinmesini sağlayabiliriz.
        public interface IUnitOfWork:IAsyncDisposable
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

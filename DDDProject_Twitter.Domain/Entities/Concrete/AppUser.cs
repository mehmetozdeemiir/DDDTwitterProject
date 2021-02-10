using DDDProject_Twitter.Domain.Entities.Interface;
using DDDProject_Twitter.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDDProject_Twitter.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IBaseEntity
    {
        //İlgili varlığın initialize edildiğinde ilişkilerinin otomatik oluşturulması için constructor method içerisine oluşturdu.Ayrıca migration işleminde kesintiler yaşanmaktadır. Bunların Önüne geçmek için yapıcı method içerisinden yapılır
        public AppUser() //NullReferanceException hatası almamak için listeleri hafızaya cıkarmam gerekiyor ctor yaptık
        {
            Tweets = new List<Tweet>();
            Likes = new List<Like>();
            Shares = new List<Share>();
            Mentions = new List<Mention>();
        }
        public string Name { get; set; }
        public string ImagePath { get; set; } = "/images/user/Default.jpg";

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public List<Tweet> Tweets { get; set; }
        public List<Like> Likes { get; set; }
        public List<Share> Shares { get; set; }
        public List<Mention> Mentions { get; set; }


        //Bir varlığı 2 farklığı yolla kullanıyoruz InverseProperty yardımıyla
        [InverseProperty("Follower")]
        public List<Follow> Followers { get; set; } //takipci
        [InverseProperty("Following")]
        public List<Follow> Followings { get; set; } //takip ettiklerim tek bir varlıkta kullanıcagım icin ınversproperty kullanıyoruz.Tek Varlık=Follow.
    }
}


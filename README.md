<h3>Bu projede DDD, asenkron programlama,Generic Repository, Unit Of Work, View Component, AutoMapper, Autofac,Fluent Validation,DTO,VM,Extension method kullanılmıştır</h3>

<h2>Domain-Driven Design</h2>:Kompleks gereksinimlerin var olduğu bir dünyada, sürekli değişen temel business kurallarını birbirine derinlemesine bağlayan bir yazılım geliştirme yaklaşımıdır. 

DDD’ın temel amacı; hızlı değişen gereksinimlere hızlı adaptasyon sağlayan, kolay ölçeklenebilir, esnek ve highly available yazılımlar üretmektir. DDD’da uygulamanın içerisinde yer alan business kurallar, mantıksal olarak domain’lere dağıtılır. Sorumluluk olarak birbiri ile en alakalı birimler aynı domain üzerinde tutulurken, diğer birimler ise farklı domain’lere taşınır. Bu yaklaşımın dayandığı temel prensipler vardır. Temel diyorum çünkü tümü değil.

DDD nin en temel kavramlarından birtanesi de 4 katmanlı mimarisidir.

· Domain Layer

· Application Layer

· Presentation Layer

· Infrastructure Layer

Application:İş süreci kurgularının ele alındığı katmandır. Uygulamanın yetenekleri bu katmanda gözlemlenebilmektedir. Domaine bağlı varlıklar bu katmanda oluşturulur ve bu katman aracılığı ile güncellemeye maruz kalırlar.

Domain:Bu katman, uygulamanın kalbidir. entities, value objects, domain services and domain events.Varlıklar-entities, değer nesneleri-value object, etki alanı hizmetleri ve etki alanı olaylarından- domain services and domain events oluşur. Domain katmanında iş süreçlerinin simüle edilmesine odaklanılır.

Infrastructure: Teknolojiye özel kararlara odaklanılır amaçtan ziyade implementasyon kısmı ile ilgilenilir.Bu katmanda domainlerin instanceları yaratılabilir.Ancak genellikle repositoryler bu katmanda etkileşim içerisinde olurlar. Veri tabanı, mesajlaşma sistemleri, email servisleri gibi dış servislere erişilen katman olacaktır.

Presentation:Bu katman dış sistemlerle etkileşimin sağlanacağı kısımdır. Bu katman bir insan, bir uygulama veya bir mesajın domainin üzerinde oluşturacağı etkilerin giriş kapısı olarak yer almaktadır.

![](https://gblobscdn.gitbook.com/assets%2F-MRpQvkt_cZoERWOLez2%2F-MShnOVhiudoDw8sZ4fT%2F-MShpRcrgUCDyUj6jS_3%2FDDDLayers1.png?alt=media&token=ebaad1a7-afcc-41e8-be9f-debcb654013c)

<h2>Unit Of Work nedir?</h2>

Veritabanı ile yapılacak olan tüm işlemleri, tek bir kanal aracılığı ile gerçekleştirme ve hafızada tutma işlemlerini sunmaktadır. Bu sayede işlemlerin toplu halde gerçekleştirilmesi ve hata durumunda geri alınabilmesi sağlamaktadır.

Tüm data işlemi yapan sınıflarınız Unit of Work içerisinde birer property olarak tutulur. Bu propertylere aynı DB connection ya da DB Context gönderilir. Property olarak gösterdiğimiz her sınıf kendi içinde değişmiş tüm datayı saklar. Unit of Work içinde bir “Save Changes” methodu olur. Bu method çağırıldığında tüm propertyler üzerindeki Save işlemleri çağırılır. Bu sayede işlemler yapılmış olur.

Avantaj olarak konuşursak, tüm DB işlemleri için dağıtık yapılarınızı tek bir sınıfta toplarsınız, transaction için rollback fonskiyonlarını ve kaydetme için save fonksiyonlarını tek bir method içinde kullanmış olursunuz. Bu da bir üst katman olan Service Layer ya da Business Intelligance Layer üzerinde işlem yaparken kolaylık sağlar. Eğer Dependency Injection kullanıyorsanız, küçük bir modifikasyonla hemen tüm DAL katmanınızı bu yapıya uygun hale getirebilirsiniz, zira çözülmesi gereken sadece DBContext nesnenizdir ve bu işlemlerin hepsi için sadece Unit of Work sınıfını güncellemeniz yeterli olacaktır.

<h2>AutoMapper nedir?</h2>
AutoMapper,Projelerimiz içerisinde tasarladığımız Dto,ViewModel gibi nesnelerimiz ile veritabanı tablolarımızı temsil eden entitylerimizi merkezi bir noktadan daha performanslı bir şekilde eşleştirmemize olanak sağlayan bir kütüphanedir.Tüm bu getirilerinin yanında bize tabiki ciddi birzaman kazandırdığı da bir gerçektir. Çok geniş bir veritabanı tablonuz olduğunu düşünün.Verinin update edilmesi aşamasında tüm propertyleri manuel olarak tek tek eşleştirmeniz gerekecek.Birde bunu bir çok kez yerde yaptığınızda ciddi bir zaman ve performans kaybı olacaktır.
İşin daha kötüsü veritabanına yeni bir alan eklediğinde ise tüm bu eşleştirmelerin hepsini tek tek düzeltmeniz yada eklemeniz gerekecek.AutoMapper ile veritabanında olan bir değişikliği tasarladığınız nesye’de eklemeniz yeterli olacaktır. Kullanılan tüm methodlarda artık mapping işlemini otomatik bir şekilde gerçekleştiriyor hale gelmiş oluyor.




## Solid Presipleri Nedir ?
Yeniden kullanılabilen,sürüdürülebilen ve anlaşılır olmasını sağlayan kod tekrarını engelleyen Robert C. Martin tarafından yazılmış presiplerdir.
Bu presiplerin amacı ; 
- Yeni bir özelliği var olan koda kolayca entegre edebilmek,
- Yeni adapte sürecinin kodu minimum değerde etkilemesi,
- Hata sürecini minimum seviyeye indirmek

İşte bu şekilde aşağıdaki presipleri uygulayarak iyi kod yazma amacına ulaşmış oluyoruz.

- S is single responsibility principle (SRP)

   Bir class birden fazla sorumluluk almamalıdır.Yani bir classın bir sorumluluğu olmalıdır.Hem nesne özelliklerini barındırıp hemde birden fazla metotu olmamalıdır.

- O stands for open closed principle (OCP)

  Bir class ya da fonksiyon davranışını değiştirmiyor fakat yeni özellikler kazanabilir olmalıdır.
  
- L Liskov substitution principle (LSP)

  Bir class kendisinden kalıtım alan bir classta özellikleri kullanılamıyorsa bu prensibe terstir.Bu nedenle bir class kendisinden kalıtım alan bir class ile kullanılabilir durumda olmalıdır.

- I interface segregation principle (ISP)

  Her bir interface'in belli bir amacı olmalıdır.Bir interface birden fazla amaca hizmet etmek yerine tek bir amac ile ilerlemelidir.Yani her bir metot grubuna belli bir interface atanmalıdır.

- D Dependency injection principle (DIP)

  Üst seviye (High-Level) sınıflar alt seviye (Low-Level) sınıflara bağlı olmamalıdır, ilişki abstraction veya interface kullanarak sağlanmalıdır,

## OOP Presipleri Nedir ?
OOP Prensipleri 4 ana prensipten oluşmaktadır. Bu prensipler ;
- Abstraction
- Polymorphizm
- Inheritence
- Encapsulation

 Bu prensipler iyi bir kod yazma düzeyine bize katkı sağlamaktadır.Standart bir kod yazma düzeyinden evrensel bir kod yazma düzeyine getirdiğini söyleyebiliriz.
 
 - Abstraction 
   Detayların artmasıyla karmaşıklığın azalmasını sağlayan prensiptir.
   - Abstract Class
   
      Sınıflar arasında pek çok ortak özellik ve davranış bulunduğu durumlarda tasarlanan soyut sınıflardır. Kod tekrarını engelleyerek hem daha derli toplu bir görüntü sağlar hem de hata yapma riskini azaltır. Abstract sınıflardan nesne üretimi gerçekleştirilemez.
   - Interface 
   
      Sınıf yapılarımız birden fazla interface ile implement edilebilir.
      Interface yapıları rehber, yol göstericiler olarak tanımlandığı için içerisinde metot oluşumları ve propertyler dışında kod blokları bulunmaz.
      Interface yapılarımızda bulunan tüm özellikler public olarak kabul edilir.
      Bir interface (arayüz) yapısını başka bir interface tarafından türetebiliriz.
      Sınıflar implement ettiği interface içerisindeki bulunan tüm özellikleri implement etmek zorundadır.
      Interface yapılarımızda oluşturduğumuz metotlar gövdesizdir. Bu yapısı ile abstract metotlara benzerlik gösterir.
      Interface (arayüz) yapılarımızı kullanarak nesneler oluşturamayız.
   



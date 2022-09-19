# ActivityAndOrganizerManagement
**Bu proje etkinliklere katılma ve organizasyonun bu etkinliği düzenleyebilmesi işlemleri için oluşturuldu.**
## İsterler
Projenin amacı, organizatörlerin etkinlik oluşturabildiği ve katılımcıların bu etkinlikleri görüp
başvurabildiği bir online etkinlik yönetim sistemi oluşturmaktır.
Bu sistem, son kullanıcılara mobil ve web ortamında çalışan farklı arayüz yazılımları ile sunulacaktır.
Ayrıca bilet satışının olduğu etkinlikler için farklı online satış kanallarıyla, ilgili etkinliklerin paylaşılması
gerekmektedir. Bu sistem üzerinden bir bilet satış işlemi yapılmayacaktır.
- Kullanıcılar üye olmadan sistemin işlevselliklerini kullanamazlar.
-  Organizatör rolüyle kayıt olan kullanıcılar düzenlemek istedikleri etkinlikleri gerekli bilgileri
girerek tanımlarlar.
- Katılımcı rolüyle kayıt olan kullanıcılar sistemde tanımlı etkinlikleri görebilirler ve istedikleri
etkinliğe katılabilirler.
- Farklı online bilet satış firmaları sistem üzerinde tanımlı ve bilet satışının olduğu etkinliklere
erişebilirler.
- Katılımcılar biletli bir etkinliğe katılmak istediklerinde sisteme entegre olmuş bilet satış firmaları
arasından istediklerini seçip onların sitesine yönlendirilirler.
- Etkinlik kategorileri, şehirler gibi bilgileri admin kullanıcısı düzenler.

## Kullanım Senaryoları
### Üye Olma
Sisteme üye olurken ad, soyad, mail adresi, şifre ve şifre tekrar bilgileri girilir. Şifre en az 8 karakter olur
ve hem harf hem rakam içerir. Üyelik esnasında organizatör veya katılımcı rolü seçilir.

Her mail adresine sadece bir üyelik tanımlıdır.

### Üye Girişi Yapma
Kullanıcılar kayıt esnasında verdikleri mail ve şifre bilgileriyle giriş yapar. Admin kullanıcısı ise sistem
ayağa kaldırılırken oluşturulan mail ve şifre bilgisiyle giriş yapar.

### Admin Kullanıcısı Olma
Admin kullanıcısı, sistem üzerinden etkinlik oluşturulurken gerekli olan kategorileri ve lokasyon için şehir
bilgilerini düzenler. Kategori ekleme, güncelleme ve kaldırma işlemlerini yapar. Aynı zamanda sistemde
geçerli şehir bilgilerini girer.
Kategorilerin sadece adı vardır ve bir ad sadece bir kategoriyi tanımlar.

### Etkinlik Düzenleme
Organizatör rolüne sahip kullanıcılar sistem üzerinde etkinlik oluşturabilir. Etkinliğin adını, gerçekleşeceği
tarihi, katılım için başvurulara kapatılacağı tarihi, açıklamasını(tanıtım yazısı, detaylar vb. için),
düzenlendiği şehri, adresini, kontenjanı, biletli olup olmadığını bilgisini ve kategorisini girer.
Kategoriyi sistemde tanımlı olan seçenekler arasından seçer. Düzenlendiği şehri sistemde tanımlı olanlar
içerisinden seçer. Eğer biletli olarak seçtiyse etkinliğin ücretini de girer.
Organizatör, etkinliği oluşturduktan sonra başvurulara kapatacağı tarihe 5 gün kalana kadar iptal
edebilir. Aynı şekilde 5 gün kalana kadar kontenjan ve etkinlik adresi bilgilerini güncelleyebilir.

### Etkinliğe Katılma
Katılımcı rolüne sahip kullanıcılar sistemde tanımlı etkinlikleri görüntülerler. İsterlerse kategori ve şehre
göre filtreleyebilirler.
İstedikleri etkinliği “Katılıyorum” seçeneği ile işaretleyebilirler. Eğer etkinlik kontenjanı dolmuşsa buna
yönelik uyarı verilir.
Kullanıcılar katıldıkları etkinlikleri listeleyebilirler.
Kullanıcı biletli bir etkinliğe katılmak isterse, bileti satın alabileceği firmaların adını görüntüler ve
istediğine tıklayarak firmanın web sitesine yönlendirilir.

### Bilet Satış Entegrasyonu
Geliştirilecek sistemde etkinlikler için bilet satışı yapılmayacaktır ancak biletli etkinlik
düzenlenebilecektir. Bu etkinlikler için bilet satışı, bu işlemi yapan firmalar üzerinden gerçekleşecektir.
Katılımcının bilet satın alması, katılımcı ile satın alma işlemini yaptığı firma arasında bir süreçtir.
Geliştirilecek sistemin bu süreçte bir dahli ve sorumluluğu yoktur.
Sisteme entegre olmak isteyen bilet firmaları öncelikle kayıt olur. Kayıt esnasında firma adı, web sitesi
alan adı, mail adresi ve şifre bilgilerini girer.
Bu firmalar, sistem üzerinde tanımlı etkinlik bilgilerini çekebilirler. Bu firmalar farklı yapılara sahip
olabileceğinden sistem bu verileri hem XML, hem de JSON formatında sunar.
Firmaların ne zaman sistemden etkinlikleri çektiği bilgisinin log kaydı tutulmalıdır.

## Projede Kullanılan Teknolojiler
- **VeriTabanı  :** MS SQL SERVER
- ASP.NET CORE 6 WEB API
- Microsost Entity Framework Core

## Projede İndirilen Paketler
- Microsoft.EntitiyFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- FluentValidation.AspNetCore
- Microsoft.AspNetCore.Authentication.JwtBearer

## Proje Açıklaması
- İlk olarak ben veri tabanında gerekli olan tabloları oluşturdum ve daha sonra da `scaffold-dbcontext "Server=.;Database=Activities;Trusted_Connection=True" Microsoft.EntityFrameworkCore.SqlServer -Output:Models` yardımıyla Activities adlı Class Library ime Models klasörü altında ekledim.

![2022-09-05](https://user-images.githubusercontent.com/86554799/188509084-2446a256-75aa-4211-84ee-16e12cb9785b.png)

- Etkinlik ve organizasyon ekleme silme güncelleme vb için Controller klasörü, DTO(Data Transfer Object) nesneleri için ViewModels klaörü ve Kullanıcın şifresini harf ve rakam içermesi gibi belirli kurallar için Validators klasörleri oluşturuldum.

![2022-09-06](https://user-images.githubusercontent.com/86554799/188594113-5bfac2af-18bc-45ac-a6b0-c860b8336e49.png)

-İlk olarak Kullanıcının kayıt olabilmesi için Ad, Soyad, Mail, Şifre, Şifre Tekrar ve Rol bilgilerini alabilmek için [UserSignUpViewModel](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/ViewModels/UserSignUpViewModel.cs) sınıfını oluşturdum ve oraya ekledim. Sonrasında kayıt işlemi yapıp rolüne göre veri tablosuna kayıt edebilmesi içinse [UserSignUpController](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/Controllers/UserSignUpController.cs) adında bir controller oluşturdum ve gerekli http metodları kullanarak işlemleri tanımladım.

**Kayıt Olma**

![kullanıcıgirişi](https://user-images.githubusercontent.com/86554799/188990983-5611742d-2619-4440-83ea-797738a038ef.gif)

![2022-09-07 (2)](https://user-images.githubusercontent.com/86554799/188992734-c925b244-dec1-4aed-b774-225fca74de10.png)


-  Şehir bilgilerinin eklenmesi, silinmesi ve güncellenmesi için ilk önce şehirin id ve isim bilgisini alabilmek için [CityViewModel](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/ViewModels/CityViewModel.cs) sınıfını oluşturdum ve oraya ekledim. Daha sonra ise şehir eklemei silme ve güncelleme işlemlerini yapılması için [CityController](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/Controllers/CityController.cs) adında conntroller ekledim ve orada gerekli http metodları kullanarak işlemleri tamamladım.

**Ekleme**

![ezgif com-gif-maker](https://user-images.githubusercontent.com/86554799/188993708-0b3b18a1-4038-4293-a8d6-26b0342d44f1.gif)

https://user-images.githubusercontent.com/86554799/188603809-acac595f-d148-4ff9-a501-4bd85031cc1a.mp4

![2022-09-06 (3)](https://user-images.githubusercontent.com/86554799/188604320-2178d22a-1005-46b1-9f2f-22a410f0ae52.png)

**Silme**

![citysilme](https://user-images.githubusercontent.com/86554799/188968760-5f57ddd4-7976-43ae-b3ac-38266f64b52a.gif)

![2022-09-06 (5)](https://user-images.githubusercontent.com/86554799/188993392-74a6ff55-4268-4ca1-8d98-c92eb2cbb140.png)

**Güncelleme**

![cityguncelleme](https://user-images.githubusercontent.com/86554799/188968845-22085b13-d1dd-41a1-bb1b-010664285e3f.gif)

![2022-09-06 (6)](https://user-images.githubusercontent.com/86554799/188993420-35959ad6-a985-4362-ad08-9604b8bc24b1.png)


-  Aynı şekilde Kategori bilgilerinin eklenmesi, silinmesi ve güncellenmesi için ilk önce kategorinin id ve isim bilgisini almak için [CategoryViewModel](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/ViewModels/CategoryViewModel.cs) sınıfını oluşturdum ve oraya ekledim. Daha sonra ise kategori eklemei silme ve güncelleme işlemlerini yapılması için [CategoryController](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/Controllers/CategoryController.cs) adında controller ekledim ve orada gerekli http metodları kullanarak işlemleri tamamladım.

**Ekleme**

![categoryekleme](https://user-images.githubusercontent.com/86554799/188986219-0175973e-bda5-4adc-810c-300e75d9b034.gif)

![2022-09-06 (7)](https://user-images.githubusercontent.com/86554799/188992987-43a68d67-e1bd-4ae4-99b3-fc6e4f3be201.png)

**Silme**

![categorysilme](https://user-images.githubusercontent.com/86554799/188986288-1aed8ebf-7cba-4ef0-9818-764188bdd6fd.gif)

![2022-09-06 (9)](https://user-images.githubusercontent.com/86554799/188992863-c9469e1f-c9cd-41d1-823c-7dca47a9bd84.png)

**Güncelleme**

![categoryguncelleme](https://user-images.githubusercontent.com/86554799/188986758-acce3aee-42b3-4582-9c50-9197e5a65e13.gif)

![2022-09-06 (8)](https://user-images.githubusercontent.com/86554799/188992923-51696b7a-e5c7-4128-9d03-a481dd93de7f.png)

- Etkinlik ekleme, silme ve güncelleyebilme işlemleri için ilk önce aktivitenin id, adı, gerçekleştirme, son başvuru tarihi ve açıklaması vb bilgileri alabilmesi için [ActivityViewModel](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/ViewModels/ActivityViewModel.cs) adında bir sınıf oluşturdum ve oraya ekledim. Daha sonra ekleme, silme ve güncelleme işlemlerini Organizatör gerçekleştirebileceği için [OrganizerController](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/Controllers/OrganizerController.cs) adında bir controller oluşturdum ve gerekli http metodları kullanarak işlemi tamamladım.

**Ekleme**

![2022-09-07 (5)](https://user-images.githubusercontent.com/86554799/188992437-51b0b31b-b0c1-47ae-8bdc-c045072ff76d.png)


**Silme**

![etkinlik silme](https://user-images.githubusercontent.com/86554799/188991597-482af07f-5cb9-48c6-ab74-2d0263c660c1.gif)

![2022-09-07 (7)](https://user-images.githubusercontent.com/86554799/188992508-c524e0e5-f294-462e-8965-a4dd809f1415.png)


**Güncelleme**

![etkinlik güncelleme](https://user-images.githubusercontent.com/86554799/188991628-e5592e28-5600-44d5-ad5f-55eb42ada560.gif)

![2022-09-07 (6)](https://user-images.githubusercontent.com/86554799/188992466-cd8cb7be-8c9e-4e62-8f72-b26de8dfc407.png)

-Kullanıcın giriş yapabilmesi ve token alarak kullanıcının rollerine göre yetkilendirme yapabilmek için kullanıcının mail ve şifre bilgilerini alabilmek için [UserLoginViewModel](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/ViewModels/UserLoginViewModel.cs) adında bir sınıf oluşturdum. Sonrasında giriş yapabilme işlemleri için [UserTokenController](https://github.com/BetulBircan/ActivityAndOrganizerManagement/blob/main/ActivityOrganizerManager/OrganizationActivityManager/Controllers/UserTokenController.cs) adında bir cotroller oluşturdum ve gerekli http metodları kullanarak işlemi tamamladım.

![Postman-2022-09-07-04-25-48](https://user-images.githubusercontent.com/86554799/188992174-f6b0aa11-eeeb-4971-894d-8ffcc5d085b8.gif)

- NOT : Projede eksiklikler devam etmekte olup güncellenmeye ve iyiliştirilmeye devam edilecek ve buradan da paylaşılmış olacaktır.





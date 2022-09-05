"# ActivityAndOrganizerManagement" 
**Bu proje etkinliklere katılma ve organizasyonun bu etkinliği düzenleyebilmesi işlemleri için  oluşturuldu.**
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
- ASP.NET CORE WEB API
- Microsost Entity Framework Core

## Projede İndirilen Paketler
- Microsoft.EntitiyFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- FluentValidation.AspNetCore
- Microsoft.AspNetCore.Authentication.JwtBearer

## Proje Açıklaması

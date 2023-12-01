# Shop
Proje 5 klasör ve 9 projeden oluşmaktadır. 
-  _DbUml
   Projenin database şemasının UML diyagramlarını içermektedir
- Core
   Proje içerisinde kullanılan nuget paketlerinin kaynak kodlarını içerir.
- CQRS
   3 projeden oluşan bu katmanda modeller (Domain), Database erişim katmanı (Persistence) ve gerekli iş kuralları ile isterlerinin gerçeklendiği katman (Application) bulunmaktadır.
- Presentation
  Sunum işlemlerinin yapıldığı UI.Api projesini içermektedir. İsterler dışında AUTH2 protokolüne uygun hazırlanmış validasyon işlemleri bulunmaktadır. İstenildiğinde JWT entegrasyonu ile stateless güvenlik sağlanabilir.
- Test
  Birim ve entegrasyon testlerini içeren sınıflar bulunmaktadır.
# Gereksinimler
- Mssql
- Mongo
- Redis
- Elastic
  Tüm gereksinimlerin docker compose dosyalarını 'DockerComposes' klasörünün altında bulabilirsiniz.
# Testler nasıl çalıştırılır ?
Test projesi içerisinde entegrasyon testleri olduğu için öncelikle Gereksinimlerin tam olarak hazır hale getirilmesi gerekmektedir.
Gereksinimler hazır hale geldiğinde build_and_run_test.bat dosyası çalıştırıldığında testler çalışacak ve sonucu gösterilecektir.
# Proje nasıl çalışır ?
Ef migrationları projede hazır haldedir. database update edildiğinde şema ve veriler otomatik initialize edilecektir.
Api projesinde 1 adet post endpointi bulunmaktadır. CustomerId ve fatura kalemleri girildiğinde response bilgisinde fatura no, fatura tutarı, hangi indirim(ler) uygulandığı gibi bilgiler hem kalem bazında hemde fatura bazında dönecektir.

# Sonarqube Raporları
![image](https://github.com/alperbasda/Shop/assets/38348843/2d63be30-bf89-473d-9ed2-d0d6e93c9d37)
Raporda gözüken güvenlik açıkları appsetting.json dosyasında bulunan connectionstring bilgilenden dolayı gelmektedir.Azure tarafına aktarıldığında vault ile bu açık kapatılabilir.

# İletişim
E-Posta : alperbasda@gmail.com
Telefon : 0551 432 73 31



 

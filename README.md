# Staj Ödevi - Görev Takip Sistemi

Bu proje staj süresince öğrendiğim ASP.NET Core MVC teknolojisini kullanarak hazırladığım küçük bir görev takip uygulamasıdır.

## Neler Yaptım?

*   Kullanıcıların kayıt olabileceği ve giriş yapabileceği bir sistem kurdum (Identity kullandım).
*   Görevleri eklemek, silmek ve güncellemek için gerekli ekranları hazırladım.
*   Herkesin sadece kendi eklediği görevleri görebilmesi için yetkilendirme ekledim.
*   Görevlerin durumunu (yapılıyor, bitti, devam ediyor) takip edebiliyoruz.

## Kullanılanlar

- .NET 9 MVC
- SQL Server (Entity Framework Core)
- Bootstrap (Tasarım için)

---

## Kurulum ve Çalıştırma

### Gereksinimler
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server veya SQL Server Express (LocalDB yeterlidir)

### 1. Repoyu klonla

```bash
git clone https://github.com/<kullanici-adi>/staj_odev.git
cd staj_odev
```

### 2. Veritabanı bağlantısını ayarla

`appsettings.json` içindeki `DefaultConnection` değerini kendi SQL Server'ına göre düzenle:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GorevYonetimDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

LocalDB kullanıyorsan bu ayarı olduğu gibi bırakabilirsin.

### 3. Migration'ları uygula

```bash
dotnet ef database update
```

> Not: Proje ilk açılışta migration'ları otomatik uygular, ancak manuel çalıştırmak daha güvenlidir.

### 4. Projeyi çalıştır

```bash
dotnet run
```

veya Visual Studio'da `F5` tuşuna bas. Uygulama `https://localhost:5001` adresinde açılır.

---

## Örnek Kullanıcı Bilgileri

Proje ilk çalıştığında otomatik olarak bir test kullanıcısı oluşturulmaktadır:

- **Email:** staj@test.com
- **Şifre:** Sifre123!

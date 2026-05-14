# Görev Takip Uygulaması

Staj öncesi ödev kapsamında geliştirilen ASP.NET Core MVC tabanlı görev yönetim uygulaması.

## Kullanılan Teknolojiler

- ASP.NET Core MVC (.NET 9)
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- ASP.NET Core Identity
- Bootstrap 5

## Özellikler

- Kullanıcı kayıt ve giriş işlemleri
- Giriş yapılmadan görev ekranlarına erişilemez
- Her kullanıcı yalnızca kendi görevlerini görür
- Görev ekleme, düzenleme, silme, listeleme ve detay görüntüleme
- Görevlerde başlık, açıklama, bitiş tarihi ve tamamlanma durumu tutulur

## Kurulum

### Gereksinimler
- .NET 9 SDK
- SQL Server veya LocalDB

### Adımlar

1. Repo klonlanır

```bash
git clone https://github.com/fierpell/staj_on_calisma.git
cd staj_on_calisma
```

2. `appsettings.json` dosyasındaki bağlantı dizesi kontrol edilir, LocalDB kullanılıyorsa değiştirilmesine gerek yoktur

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GorevYonetimDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

3. Veritabanı oluşturulur

```bash
dotnet ef database update
```

4. Proje çalıştırılır

```bash
dotnet run
```

Tarayıcıda `http://localhost:5157` adresine gidilir.

## Test Kullanıcısı

Proje ilk açılışta aşağıdaki kullanıcıyı otomatik olarak oluşturur:

- **Email:** staj@test.com  
- **Şifre:** Sifre123!

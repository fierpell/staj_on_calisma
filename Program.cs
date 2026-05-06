using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using staj_odev.Data;

var builder = WebApplication.CreateBuilder(args);

// veritabanı bağlantısı
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// identity ayarları - şifre kurallarını biraz gevşettim
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// giriş yapmamış kullanıcıları giriş sayfasına yönlendir
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Hesap/Giris";
    options.LogoutPath = "/Hesap/Cikis";
    options.AccessDeniedPath = "/Hesap/Giris";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AnaSayfa/Hata");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gorevler}/{action=Index}/{id?}");

app.Run();

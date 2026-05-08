using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using staj_odev.ViewModels;

namespace staj_odev.Controllers
{
    public class HesapController : Controller
    {
        private readonly UserManager<IdentityUser> _kullaniciYoneticisi;
        private readonly SignInManager<IdentityUser> _oturumYoneticisi;

        public HesapController(UserManager<IdentityUser> kullaniciYoneticisi, SignInManager<IdentityUser> oturumYoneticisi)
        {
            _kullaniciYoneticisi = kullaniciYoneticisi;
            _oturumYoneticisi = oturumYoneticisi;
        }

        [HttpGet]
        public IActionResult Kayit() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Kayit(KayitViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var kullanici = new IdentityUser { UserName = model.Eposta, Email = model.Eposta };
            var sonuc = await _kullaniciYoneticisi.CreateAsync(kullanici, model.Sifre);

            if (sonuc.Succeeded)
            {
                await _oturumYoneticisi.SignInAsync(kullanici, isPersistent: false);
                return RedirectToAction("Index", "Gorevler");
            }

            foreach (var hata in sonuc.Errors)
                ModelState.AddModelError(string.Empty, hata.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult Giris(string? donusUrl = null)
        {
            ViewData["ReturnUrl"] = donusUrl;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris(GirisViewModel model, string? donusUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var sonuc = await _oturumYoneticisi.PasswordSignInAsync(model.Eposta, model.Sifre, model.BeniHatirla, lockoutOnFailure: false);

            if (sonuc.Succeeded)
                return LocalRedirect(donusUrl ?? Url.Action("Index", "Gorevler")!);

            ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre.");
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Cikis()
        {
            await _oturumYoneticisi.SignOutAsync();
            return RedirectToAction("Giris");
        }
    }
}

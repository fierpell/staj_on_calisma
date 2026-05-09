using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staj_odev.Data;
using staj_odev.Models;
using staj_odev.ViewModels;

namespace staj_odev.Controllers
{
    [Authorize] // giriş yapmayan kullanıcılar bu sayfaya erişemez
    public class GorevlerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GorevlerController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // görev listesini getir, önce tamamlanmayanlar gösterilsin
        public async Task<IActionResult> Index()
        {
            var kullaniciId = _userManager.GetUserId(User)!;
            var gorevler = await _context.Gorevler
                .Where(g => g.KullaniciId == kullaniciId)
                .OrderBy(g => g.Tamamlandi)
                .ThenBy(g => g.BitisTarihi)
                .Select(g => new GorevViewModel
                {
                    Id = g.Id,
                    Baslik = g.Baslik,
                    Aciklama = g.Aciklama,
                    BitisTarihi = g.BitisTarihi,
                    Tamamlandi = g.Tamamlandi,
                    OlusturulmaTarihi = g.OlusturulmaTarihi
                })
                .ToListAsync();

            return View(gorevler);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var kullaniciId = _userManager.GetUserId(User)!;
            var gorev = await _context.Gorevler.FirstOrDefaultAsync(g => g.Id == id && g.KullaniciId == kullaniciId);
            if (gorev == null) return NotFound();

            return View(new GorevViewModel
            {
                Id = gorev.Id,
                Baslik = gorev.Baslik,
                Aciklama = gorev.Aciklama,
                BitisTarihi = gorev.BitisTarihi,
                Tamamlandi = gorev.Tamamlandi,
                OlusturulmaTarihi = gorev.OlusturulmaTarihi
            });
        }

        [HttpGet]
        public IActionResult Create() => View(new GorevViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GorevViewModel model) // formdan gelen veriyi kaydet
        {
            if (!ModelState.IsValid) return View(model);

            var gorev = new Gorev
            {
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                BitisTarihi = model.BitisTarihi,
                Tamamlandi = false,
                OlusturulmaTarihi = DateTime.UtcNow,
                KullaniciId = _userManager.GetUserId(User)!
            };

            _context.Gorevler.Add(gorev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var kullaniciId = _userManager.GetUserId(User)!;
            var gorev = await _context.Gorevler.FirstOrDefaultAsync(g => g.Id == id && g.KullaniciId == kullaniciId);
            if (gorev == null) return NotFound();

            return View(new GorevViewModel
            {
                Id = gorev.Id,
                Baslik = gorev.Baslik,
                Aciklama = gorev.Aciklama,
                BitisTarihi = gorev.BitisTarihi,
                Tamamlandi = gorev.Tamamlandi,
                OlusturulmaTarihi = gorev.OlusturulmaTarihi
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GorevViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var kullaniciId = _userManager.GetUserId(User)!;
            var gorev = await _context.Gorevler.FirstOrDefaultAsync(g => g.Id == id && g.KullaniciId == kullaniciId);
            if (gorev == null) return NotFound();

            gorev.Baslik = model.Baslik;
            gorev.Aciklama = model.Aciklama;
            gorev.BitisTarihi = model.BitisTarihi;
            gorev.Tamamlandi = model.Tamamlandi;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var kullaniciId = _userManager.GetUserId(User)!;
            var gorev = await _context.Gorevler.FirstOrDefaultAsync(g => g.Id == id && g.KullaniciId == kullaniciId);
            if (gorev == null) return NotFound();

            return View(new GorevViewModel
            {
                Id = gorev.Id,
                Baslik = gorev.Baslik,
                Aciklama = gorev.Aciklama,
                BitisTarihi = gorev.BitisTarihi,
                Tamamlandi = gorev.Tamamlandi,
                OlusturulmaTarihi = gorev.OlusturulmaTarihi
            });
        }

        // silme onaylandıktan sonra çalışır
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullaniciId = _userManager.GetUserId(User)!;
            var gorev = await _context.Gorevler.FirstOrDefaultAsync(g => g.Id == id && g.KullaniciId == kullaniciId);
            if (gorev == null) return NotFound();

            _context.Gorevler.Remove(gorev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

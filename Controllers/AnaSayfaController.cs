using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using staj_odev.Models;

namespace staj_odev.Controllers;

public class AnaSayfaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Gizlilik()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Hata()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

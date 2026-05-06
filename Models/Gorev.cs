using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace staj_odev.Models
{
    // veritabanındaki gorevler tablosuna karşılık gelen model
    public class Gorev
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Baslik { get; set; } = string.Empty;

        public string? Aciklama { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.UtcNow;

        public DateTime? BitisTarihi { get; set; }

        public bool Tamamlandi { get; set; }

        public string KullaniciId { get; set; } = string.Empty;

        public IdentityUser? Kullanici { get; set; }
    }
}

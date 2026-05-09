using System.ComponentModel.DataAnnotations;

namespace staj_odev.ViewModels
{
    public class GorevViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(200)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BitisTarihi { get; set; }

        [Display(Name = "Tamamlandı")]
        public bool Tamamlandi { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
    }
}

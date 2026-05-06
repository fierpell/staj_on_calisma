using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using staj_odev.Models;

namespace staj_odev.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Gorev> Gorevler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Gorev>()
                .HasOne(t => t.Kullanici)
                .WithMany()
                .HasForeignKey(t => t.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

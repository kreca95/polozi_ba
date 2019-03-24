using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using polozi_ba.Data.Models;

namespace polozi_ba.Data
{
    public class PoloziBaContext : IdentityDbContext<Korisnik>
    {
        public PoloziBaContext(DbContextOptions<PoloziBaContext> options)
            : base(options)
        {

        }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<KorisnikPredmet> KorisnikPredmet { get; set; }
        public DbSet<KorisnikGrad> KorisnikGrad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region veza vise-vise izmedju korisnika i predmeta
            builder.Entity<KorisnikPredmet>()
                .HasKey(x => new { x.KorisnikId, x.PredmetId });

            builder.Entity<KorisnikPredmet>()
                .HasOne(x => x.Korisnik)
                .WithMany(x => x.KorisnikPredmeti)
                .HasForeignKey(x => x.KorisnikId);

            builder.Entity<KorisnikPredmet>()
                .HasOne(x => x.Predmet)
                .WithMany(x => x.KorisnikPredmeti)
                .HasForeignKey(x => x.PredmetId);
            #endregion

            #region veza vise-vise izmedju korisnika i grada
            builder.Entity<KorisnikGrad>()
                .HasKey(x => new { x.KorisnikId, x.GradId });

            builder.Entity<KorisnikGrad>()
                .HasOne(x => x.Korisnik)
                .WithMany(x => x.KorisnikGrad)
                .HasForeignKey(x => x.KorisnikId);

            builder.Entity<KorisnikGrad>()
                .HasOne(x => x.Grad)
                .WithMany(x => x.KorisnikGrad)
                .HasForeignKey(x => x.GradId);
            #endregion
        }
    }
}

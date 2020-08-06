namespace VokaTester.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data.Models;
    using VokaTester.Infrastructure.Services;

    public class VokaTesterDbContext : IdentityDbContext<User>
    {
        public VokaTesterDbContext(
            DbContextOptions<VokaTesterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bereich> Bereich { get; set; }

        public DbSet<FehlerArt> FehlerArt { get; set; }
        
        public DbSet<Fortschritt> Fortschritt { get; set; }

        public DbSet<Lektion> Lektion { get; set; }

        public DbSet<TestResult> TestResult { get; set; }

        public DbSet<Vokabel> Vokabel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Fortschritt>()
                .HasOne(x => x.User)
                .WithMany(x => x.Fortschritte)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Fortschritt>()
                .HasOne(x => x.Lektion)
                .WithMany(x => x.Fortschritte)
                .HasForeignKey(x => x.LektionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Fortschritt>()
                .HasOne(x => x.LetzteVokabelCorrect)
                .WithMany(x => x.FortschritteCorrect)
                .HasForeignKey(x => x.LetzteVokabelCorrectId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<Fortschritt>()
                .HasOne(x => x.LetzteVokabelWrong)
                .WithMany(x => x.FortschritteWrong)
                .HasForeignKey(x => x.LetzteVokabelWrongId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Vokabel>()
                .HasOne(x => x.Lektion)
                .WithMany(x => x.Vokabeln)
                .HasForeignKey(x => x.LektionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Vokabel>()
                .HasOne(x => x.Bereich)
                .WithMany(x => x.Vokabeln)
                .HasForeignKey(x => x.BereichId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

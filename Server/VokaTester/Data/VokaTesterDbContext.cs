namespace VokaTester.Data
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data.Models;

    public class VokaTesterDbContext : IdentityDbContext<User>
    {
        public VokaTesterDbContext(DbContextOptions<VokaTesterDbContext> options)
            : base(options)
        {
        }

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
                .Entity<Vokabel>()
                .HasOne(x => x.Lektion)
                .WithMany(x => x.Vokabeln)
                .HasForeignKey(x => x.LektionId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

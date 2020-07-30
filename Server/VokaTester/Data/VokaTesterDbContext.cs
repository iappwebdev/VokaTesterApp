namespace VokaTester.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using VokaTester.Data.Models;
    using VokaTester.Infrastructure.Services;

    public class VokaTesterDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public VokaTesterDbContext(
            DbContextOptions<VokaTesterDbContext> options,
            ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<Bereich> Bereich { get; set; }

        public DbSet<Lektion> Lektion { get; set; }

        public DbSet<Vokabel> Vokabel { get; set; }

        //public DbSet<Wort> Wörter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //    .Entity<Fortschritt>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.Fortschritte)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Fortschritt>()
            //    .HasOne(x => x.Lektion)
            //    .WithMany(x => x.Fortschritte)
            //    .HasForeignKey(x => x.LektionId)
            //    .OnDelete(DeleteBehavior.Restrict);

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

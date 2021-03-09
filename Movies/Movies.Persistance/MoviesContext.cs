using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Persistance
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions options)
            : base(options){ }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<MovieEntity> Movies { get; set; }

        public DbSet<GenreEntity> Genres { get; set; }

        public DbSet<MovieGenreEntity> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MoviesContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var createdEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            createdEntities.ForEach(e =>
            {
                var now = DateTime.Now;
                e.Property(nameof(BaseEntity.CreatedOn)).CurrentValue = now;
                e.Property(nameof(BaseEntity.ModifiedOn)).CurrentValue = now;
            });

            var modifiedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            modifiedEntities.ForEach(e =>
            {
                e.Property(nameof(BaseEntity.ModifiedOn)).CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}

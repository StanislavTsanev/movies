using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Persistance.Configurations
{
    internal class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenreEntity>
    {
        public void Configure(EntityTypeBuilder<MovieGenreEntity> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.GenreId });
        }
    }
}

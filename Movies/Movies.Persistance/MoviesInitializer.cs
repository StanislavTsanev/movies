using Movies.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Persistance
{
    public class MoviesInitializer
    {
        private readonly Dictionary<int, GenreEntity> _roles = new Dictionary<int, GenreEntity>();

        public static void Initialize(MoviesContext context)
        {
            new MoviesInitializer().Seed(context);
        }

        public void Seed(MoviesContext context)
        {
            SeedGenres(context);
        }

        public void SeedGenres(MoviesContext context)
        {
            if (context.Genres.Any())
            {
                return;
            }

            var comedyGenreEntity = new GenreEntity()
            {
                Name = "Comedy",
            };

            var actionGenreEntity = new GenreEntity()
            {
                Name = "Action",
            };

            var scifiGenreEntity = new GenreEntity()
            {
                Name = "Sci-fi",
            };

            var dramaGenreEntity = new GenreEntity()
            {
                Name = "Drama",
            };

            var crimeGenreEntity = new GenreEntity()
            {
                Name = "Crime",
            };

            context.Genres.AddRange(new GenreEntity[]
            {
                comedyGenreEntity,
                actionGenreEntity,
                scifiGenreEntity,
                dramaGenreEntity,
                crimeGenreEntity
            });

            context.SaveChanges();

            _roles.Add(comedyGenreEntity.Id, comedyGenreEntity);
            _roles.Add(actionGenreEntity.Id, actionGenreEntity);
            _roles.Add(scifiGenreEntity.Id, scifiGenreEntity);
            _roles.Add(dramaGenreEntity.Id, dramaGenreEntity);
            _roles.Add(crimeGenreEntity.Id, crimeGenreEntity);
        }
    }
}

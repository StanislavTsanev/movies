using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class GenreEntity
    {
        public GenreEntity()
        {
            MovieGenres = new HashSet<MovieGenreEntity>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MovieGenreEntity> MovieGenres { get; set; }
    }
}

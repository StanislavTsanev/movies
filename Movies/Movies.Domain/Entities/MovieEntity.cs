using System;
using System.Collections.Generic;

namespace Movies.Domain.Entities
{
    public class MovieEntity : BaseEntity
    {
        public MovieEntity()
        {
            MovieGenres = new HashSet<MovieGenreEntity>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte[] Poster { get; set; }

        public virtual ICollection<MovieGenreEntity> MovieGenres { get; set; }
    }
}

﻿using Movies.Domain.Entities;

namespace Movies.Domain
{
    public class MovieGenreEntity : BaseEntity
    {
        public int MovieId { get; set; }

        public MovieEntity Movie { get; set; }

        public int GenreId { get; set; }

        public GenreEntity Genre { get; set; }
    }
}

using Movies.Application.Features.Genres.Dtos;
using System;
using System.Collections.Generic;

namespace Movies.Application.Features.Movies.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte[] Poster { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }
    }
}

using System.Collections.Generic;

namespace Movies.Application.Features.Genres.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> MovieIds { get; set; }
    }
}

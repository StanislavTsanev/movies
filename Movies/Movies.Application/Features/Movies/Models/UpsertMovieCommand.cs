using Movies.Application.Common.Models.Mediatr;
using Movies.Domain.Entities;
using System;

namespace Movies.Application.Features.Movies.Models
{
    public class UpsertMovieCommand : BaseCommand<MovieEntity>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte[] Poster { get; set; }
    }
}

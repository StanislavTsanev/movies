using Microsoft.AspNetCore.Http;
using System;

namespace Movies.API.Models.BindingModels
{
    public class UpdateMovieBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public IFormFile Poster { get; set; }
    }
}

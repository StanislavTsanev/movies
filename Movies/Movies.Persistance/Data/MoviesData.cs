using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Movies.Persistance.Data
{
    public class MoviesData : IData
    {
        private readonly MoviesContext _moviesContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public MoviesData(
            MoviesContext moviesContext,
            IAsyncRepository<UserEntity> users,
            IAsyncRepository<MovieEntity> movies,
            IAsyncRepository<GenreEntity> genres,
            IAsyncRepository<MovieGenreEntity> movieGenres)
        {
            _moviesContext = moviesContext;
            Users = users;
            Movies = movies;
            Genres = genres;
            MovieGenres = movieGenres;
        }

        public IAsyncRepository<UserEntity> Users { get; }

        public IAsyncRepository<MovieEntity> Movies { get; }

        public IAsyncRepository<GenreEntity> Genres { get; }

        public IAsyncRepository<MovieGenreEntity> MovieGenres { get; }

        public IAsyncRepository<TEntity> Repository<TEntity>() 
            where TEntity : BaseEntity
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                var repoProp = GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .First(x => x.PropertyType.GetGenericArguments()[0] == entityType);

                var repo = repoProp.GetValue(this);

                _repositories.Add(entityType, repo);
            }

            return (IAsyncRepository<TEntity>)_repositories[entityType];
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _moviesContext.SaveChangesAsync();
        }
    }
}

using Movies.Domain.Entities;
using System.Threading.Tasks;

namespace Movies.Application.Common.Interfaces
{
    public interface IData
    {
        //IAsyncRepository<UserEntity> Users { get; }

        IAsyncRepository<MovieEntity> Movies { get; }

        IAsyncRepository<GenreEntity> Genres { get; }

        IAsyncRepository<MovieGenreEntity> MovieGenres { get; }

        IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}

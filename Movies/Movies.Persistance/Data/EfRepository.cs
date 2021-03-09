using Microsoft.EntityFrameworkCore;
using Movies.Application.Common.Interfaces;
using Movies.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Persistance.Data
{
    public class EfRepository<T> : IAsyncRepository<T>
        where T : BaseEntity
    {
        protected readonly MoviesContext _moviesContext;

        public EfRepository(MoviesContext dbContext)
        {
            _moviesContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _moviesContext.Set<T>().AddAsync(entity);

            return await Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _moviesContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _moviesContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _moviesContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _moviesContext.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}

using DockerComposeTesting.Core.Abstractions.Domain;
using DockerComposeTesting.Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeTesting.Data.Abstractions.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LibraryDbContext _dataContext;

        public Repository(LibraryDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _dataContext.Set<T>().ToListAsync(cancellationToken);
            return entities;
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _dataContext.AddAsync(entity);
            return entity;
        }
    }
}

using DockerComposeTesting.Core.Abstractions.Domain;

namespace DockerComposeTesting.Core.Abstractions.Repositories
{
    public interface IRepository<T>
         where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
    }
}

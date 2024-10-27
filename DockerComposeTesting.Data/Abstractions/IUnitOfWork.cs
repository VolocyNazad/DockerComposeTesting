using DockerComposeTesting.Core.Domain;
using DockerComposeTesting.Data.Abstractions.Repositories;

namespace DockerComposeTesting.Data.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        Repository<Book> BookRepository { get; }
    }
}

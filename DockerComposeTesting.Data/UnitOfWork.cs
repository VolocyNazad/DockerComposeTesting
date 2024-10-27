using DockerComposeTesting.Core.Domain;
using DockerComposeTesting.Data.Abstractions;
using DockerComposeTesting.Data.Abstractions.Repositories;

namespace DockerComposeTesting.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _db;
        private Repository<Book>? _bookRepository;

        public UnitOfWork(LibraryDbContext db)
        {
            _db = db;
        }

        public Repository<Book> BookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new Repository<Book>(_db);
                return _bookRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

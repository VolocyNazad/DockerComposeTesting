using DockerComposeTesting.Data.Abstractions.Data;
using Microsoft.Extensions.Options;

namespace DockerComposeTesting.Data.Data
{
    internal class DbInitializerOptions
    {
        public bool IsActive {  get; set; }
        public bool Regenerate {  get; set; }
    }

    internal class DbInitializer : IDbInitializer
    {
        private readonly LibraryDbContext _dataContext;
        private readonly DbInitializerOptions _options;

        public DbInitializer(LibraryDbContext dataContext, IOptions<DbInitializerOptions> options)
        {
            _dataContext = dataContext;
            _options = options.Value;
        }

        public void Initialize()
        {
            if (!_options.IsActive) return;
            if (_options.Regenerate)
                _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();
        }
    }
}

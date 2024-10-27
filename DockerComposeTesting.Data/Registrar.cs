using DockerComposeTesting.Core.Abstractions.Repositories;
using DockerComposeTesting.Data.Abstractions;
using DockerComposeTesting.Data.Abstractions.Data;
using DockerComposeTesting.Data.Abstractions.Repositories;
using DockerComposeTesting.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DockerComposeTesting.Data
{
    public static class Registrar
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration) => services
            .AddOptions()
            .Configure<DbInitializerOptions>(configuration.GetSection("Initialization"))
            .AddTransient(typeof(IRepository<>), typeof(Repository<>))
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient<IDbInitializer, DbInitializer>()
            .AddDbContext<LibraryDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies();

                var type = configuration["Type"];
                var connection = configuration.GetConnectionString(type);
                switch (type)
                {
                    case null: throw new InvalidOperationException("Database type not defined");

                    default: throw new InvalidOperationException($"Connection type not supported. Type: {type}.");

                    case "Npgsql":
                        opt.UseNpgsql(connection);
                        break;
                }

                opt.UseSnakeCaseNamingConvention();
            })
            ;
    }
}

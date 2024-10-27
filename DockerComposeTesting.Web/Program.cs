using DockerComposeTesting.Data;
using DockerComposeTesting.Data.Abstractions.Data;

namespace DockerComposeTesting.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddData(builder.Configuration.GetSection("Database"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // Database initialization
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                services.Initialize();
            }

            app.Run();

        }
    }
}

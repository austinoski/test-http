
namespace test_http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            WebApplication? app = null;

            // Add services to the container.

            var configuration = builder.Configuration;
            var isLocal = configuration["AppConfiguration:Env"] == "local";
            var allowLocalRun = configuration["AppConfiguration:AllowLocalRun"] == "true";
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (isLocal && allowLocalRun)
            {
                app = builder.Build();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
using Api.Hubs;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHealthChecks();
        builder.Services.AddSignalR();
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
        }
        app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseHealthChecks("/healthcheck");
        app.MapHub<MyHub>("/my-hub");
        app.MapControllers();

        app.Run();
    }
}
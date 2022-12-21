using Api.Hubs;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHealthChecks();
        builder.Services.AddControllers();
        builder.Services.AddSignalR();

        var app = builder.Build();

        app.UseCors(builder => builder

            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseHealthChecks("/healthcheck");
        app.MapHub<MyHub>("/my-hub");
        app.MapControllers();

        app.Run();
    }
}
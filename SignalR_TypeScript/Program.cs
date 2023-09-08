using SignalR_TypeScript.Hubs;

namespace SignalR_TypeScript
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapGet("/", () => "Hello World!");

            app.MapHub<ChatHub>("/hub");

            app.Run();
        }
    }
}
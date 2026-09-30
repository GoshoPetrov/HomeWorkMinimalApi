
using HomeWorkk.Endpoints;

namespace HomeWorkk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.MapUserEndpoints();

            app.Run();
        }
    }
}

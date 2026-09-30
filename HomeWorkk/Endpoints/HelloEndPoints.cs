namespace HomeWorkk.Endpoints
{
    public static class HelloEndPoints
    {

        public static void MapHelloEndpoints(this WebApplication app)
        {
            app.MapGet("/", () =>
            {
                return "Hello World!";
            });
        }
    }
}

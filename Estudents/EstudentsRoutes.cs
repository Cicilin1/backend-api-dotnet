namespace backend_api_dotnet.Estudents
{
    public static class EstudentsRoutes
    {
        public static void AddEstudentsRoutes(WebApplication app)
        {
            app.MapGet("/", handler: () => "Hello-world!");
        }
    }
}

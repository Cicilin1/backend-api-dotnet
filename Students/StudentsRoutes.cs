using backend_api_dotnet.Estudents;

namespace backend_api_dotnet.Students
{
    public static class StudentsRoutes
    {
        public static void AddStudentsRoutes(this WebApplication app)
        {
            app.MapGet("students", 
                handler: () => new Student("Cicilini"));
        }
    }
}

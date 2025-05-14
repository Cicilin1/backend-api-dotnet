using backend_api_dotnet.Estudents;
using backend_api_dotnet.Students;
using backend_api_dotnet.Data;

namespace backend_api_dotnet.Students
{
    public static class StudentsRoutes
    {
        public static void AddStudentsRoutes(this WebApplication app)
        {
            var routesStudents = app.MapGroup(prefix: "student");

            routesStudents.MapPost("",
                async (AddStudentRequest request, AppDbContext context ) => 
            {
                var newStudent = new Student(request.Name);

                await context.TableStudent.AddAsync(newStudent);
                await context.SaveChangesAsync();   
            });
        }
    }
}

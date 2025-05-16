using backend_api_dotnet.Estudents;
using backend_api_dotnet.Students;
using backend_api_dotnet.Data;
using Microsoft.EntityFrameworkCore;

namespace backend_api_dotnet.Students
{
    public static class StudentsRoutes
    {
        public static async void AddStudentsRoutes(this WebApplication app)
        {
            var routesStudents = app.MapGroup(prefix: "student");

            routesStudents.MapPost("",
                async (AddStudentRequest request, AppDbContext context) =>
            {

                var IsExist = await context.TableStudent.AnyAsync(Student => Student.Name == request.Name);

                if (IsExist)
                    return Results.Conflict(error: "Esse nome já existe!");

                var newStudent = new Student(request.Name);

                await context.TableStudent.AddAsync(newStudent);
                await context.SaveChangesAsync();

                return Results.Ok(newStudent);
            });


            routesStudents.MapGet("",
                async (AppDbContext context) =>
            {
                var students = await context.TableStudent.Where(TableStudent => TableStudent.IsActive).ToListAsync();
                return students;
            });



            routesStudents.MapPut("{id:guid}",
                async (Guid id, UpdateStudentRequest request, AppDbContext context) =>
                {
                    var students = await context.TableStudent.SingleOrDefaultAsync(Student => Student.Id == id);

                    if (students == null)
                    {
                        return Results.NotFound();
                    }

                    students.UpdateName(request.Name);

                    await context.SaveChangesAsync();
                    return Results.Ok(students);

                });


        }
    }
}

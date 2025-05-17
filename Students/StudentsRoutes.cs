using backend_api_dotnet.Estudents;
using backend_api_dotnet.Students;
using backend_api_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend_api_dotnet.Students
{
    public static class StudentsRoutes
    {
        public static async void AddStudentsRoutes(this WebApplication app)
        {
            var routesStudents = app.MapGroup(prefix: "student");

            routesStudents.MapPost("",
                async (AddStudentRequest request, AppDbContext context, CancellationToken ct) =>
            {

                var IsExist = await context.TableStudent.AnyAsync(Student => Student.Name == request.Name, ct);

                if (IsExist)
                    return Results.Conflict(error: "Esse nome já existe!");

                var newStudent = new Student(request.Name);

                await context.TableStudent.AddAsync(newStudent, ct);
                await context.SaveChangesAsync(ct);

                return Results.Ok(newStudent);
            });


            routesStudents.MapGet("",
                async (AppDbContext context, CancellationToken ct) =>
            {
                var students = await context.TableStudent.Where(TableStudent => TableStudent.IsActive).ToListAsync(ct);
                return students;
            });



            routesStudents.MapPut("{id:guid}",
                async (Guid id, UpdateStudentRequest request, AppDbContext context, CancellationToken ct) =>
                { 
                    var students = await context.TableStudent.SingleOrDefaultAsync(Student => Student.Id == id, ct);

                    if (students == null)
                    {
                        return Results.NotFound();
                    }

                    students.UpdateName(request.Name);

                    await context.SaveChangesAsync(ct);
                    return Results.Ok(students);

                });


            routesStudents.MapDelete("{id}",
                async (Guid id, AppDbContext context, CancellationToken ct) =>
                {
                    var students = await context.TableStudent.SingleOrDefaultAsync(Student => Student.Id == id, ct);

                    if (students == null)
                    {
                        return Results.NotFound();
                    }

                    students.Desative();

                    await context.SaveChangesAsync(ct);
                    return Results.Ok(students);
                });

        }
    }
}

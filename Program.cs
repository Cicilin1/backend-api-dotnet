using backend_api_dotnet.Estudents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("Hello-word", handler: () => "Hello world!");

EstudentsRoutes.AddEstudentsRoutes(app);

app.Run();


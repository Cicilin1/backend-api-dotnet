using Microsoft.EntityFrameworkCore;
using backend_api_dotnet.Students;
using backend_api_dotnet.Estudents;

namespace backend_api_dotnet.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> TableStudent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString:"Data Source=Banco.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

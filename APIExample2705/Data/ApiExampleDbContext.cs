using APIExample2705.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIExample2705.Data
{
    public class ApiExampleDbContext:DbContext
    {
        public ApiExampleDbContext(DbContextOptions options):base(options) { }

        public DbSet<Araba> Arabalar {  get; set; }
    }
}

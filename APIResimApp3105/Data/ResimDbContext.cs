using Microsoft.EntityFrameworkCore;

namespace APIResimApp3105.Data
{
    public class ResimDbContext:DbContext
    {
        public ResimDbContext(DbContextOptions options):base(options){ }
        public DbSet<Resim> Resimler { get; set; }
    }
}

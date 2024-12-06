using Microsoft.EntityFrameworkCore;
using MiAplicacionConApi.Domain;

namespace MiAplicacionConApi.Data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }
}

}

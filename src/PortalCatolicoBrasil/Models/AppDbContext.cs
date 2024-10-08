using Microsoft.EntityFrameworkCore;

namespace PortalCatolicoBrasil.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

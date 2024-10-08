using Microsoft.EntityFrameworkCore;

namespace PortalCatolicoBrasil.Models
{
    public class EventosDbContext:DbContext
    {
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
    }
}

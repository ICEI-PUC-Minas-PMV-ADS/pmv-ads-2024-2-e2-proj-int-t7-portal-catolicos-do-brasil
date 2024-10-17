using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<Evento> Eventos { get; set; }
 


}
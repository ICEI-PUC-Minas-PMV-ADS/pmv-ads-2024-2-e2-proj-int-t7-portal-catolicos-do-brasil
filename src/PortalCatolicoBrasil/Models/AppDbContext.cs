using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Evento> Evento { get; set; }
    public DbSet<SantoDia> SantoDia { get; set; }
    public DbSet<Igreja> Igreja { get; set; }
    public DbSet<Missa> Missa { get; set; }

}
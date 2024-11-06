using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Evento> Evento { get; set; }
    public DbSet<SantoDia> SantoDia { get; set; }
    public DbSet<Igreja> Igreja { get; set; }
    public DbSet<DiaMissa> DiaMissa { get; set; }
    public DbSet<HoraMissa> HoraMissa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
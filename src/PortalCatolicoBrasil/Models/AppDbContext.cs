using Microsoft.EntityFrameworkCore;
using PortalCatolicoBrasil.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Liturgia> Liturgia { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<SantoDia> SantoDia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Liturgia>()
            .HasNoKey();

    }
}

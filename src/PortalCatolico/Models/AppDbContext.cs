using Microsoft.EntityFrameworkCore;
using PortalCatolico.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Evento> Evento { get; set; }
    public DbSet<SantoDia> SantoDia { get; set; }
    public DbSet<Igreja> Igreja { get; set; }
    public DbSet<Missa> Missa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IgrejaMissaViewModel>()
            .HasNoKey();
        modelBuilder.Entity<EventoViewModel>()
            .HasNoKey();
    }
}
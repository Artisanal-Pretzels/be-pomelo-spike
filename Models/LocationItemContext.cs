using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace be_pomelo_spike.Models
{
  public class LocationItemContext : DbContext
  {

    public LocationItemContext(DbContextOptions<LocationItemContext> options) : base(options) { }
    public DbSet<LocationItem> LocationItem { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<LocationItem>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Latitude);
        entity.Property(e => e.Longitude);
        entity.Property(e => e.Name);
      });
    }

  }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Seaknots.TCMS.Entities;

namespace Seaknots.TCMS.DataAccess
{
  public class TCMSContext : DbContext
  {
    public TCMSContext()
    {
    }

    public TCMSContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<TankAgency> TankAgencies { get; set; }
    public DbSet<TankOperator> TankOperators { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<CorporateOffice> CorporateOffices { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Code> ProductNames { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.RemovePluralizingTableNameConvention();
      modelBuilder.Entity<Product>()
                  .HasKey(x => x.ID);
    }
  }

  public static class ModelBuilderExtensions
  {
    public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
    {
      foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
      {
        entity.Relational().TableName = entity.DisplayName();
      }
    }
  }
}

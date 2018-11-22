using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Seaknots.TCMS.Entities;

namespace Seaknots.TCMS.DataAccess
{
  public class TCMSContext : DbContext
  {
    public TCMSContext() {}

    public TCMSContext(DbContextOptions options) : base(options) {}

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<TankAgency> TankAgencies { get; set; }
    public DbSet<TankOperator> TankOperators { get; set; }
    public DbSet<OperatorType> TanksOperatorTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<VendorType> VenodrTypes { get; set; }
    public DbSet<CorporateOffice> CorporateOffices { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Code> ProductNames { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Code> ProductCodes { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Credit> Credits { get; set; }
    public DbSet<Credentials> Credentials { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyType> CompanyTypes { get; set; }
    public DbSet<Port> Ports { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<BankInfo> Banks { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Logo> Logos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.RemovePluralizingTableNameConvention();
      modelBuilder.Entity<User>().HasKey(c => new { c.UserID, c.Email });
      modelBuilder.Entity<Role>().HasKey(c => new { c.RoleID, c.Name });
      modelBuilder.Entity<CorporateOffice>().HasKey(c => new { c.CoID, c.GlobalID });
      //{
      //  entity.haskey(c => new { c.coid, c.globalid });
      //  entity.hasone(x => x.bankinfo)
      //          .withmany()
      //          .hasforeignkey(x => x.bankid);
      //  entity.hasone(x => x.logo)
      //          .withmany()
      //          .hasforeignkey(x => x.logoid);
      //});
      //modelbuilder.entity<corporateoffice>(entity =>
      //{
      //  entity.haskey(c => new { c.coid, c.globalid });
      //  entity.hasone(x => x.bankinfo)
      //          .withmany()
      //          .hasforeignkey(x => x.bankid);
      //  entity.hasone(x => x.logo)
      //          .withmany()
      //          .hasforeignkey(x => x.logoid);
      //});
      //modelBuilder.Entity<CorporateOffice>().HasOne(c => c.GlobalID).WithOne().HasForeignKey<BankInfo>(x => x.GlobalID);
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

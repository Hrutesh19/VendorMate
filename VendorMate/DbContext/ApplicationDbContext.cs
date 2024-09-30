

namespace YourNamespace.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using VendorMate.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Initialize collections
        PurchaseOrderHeaders = Set<PurchaseOrderHeader>();
        MaterialMasters = Set<MaterialMaster>();
    }

    public DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    public DbSet<MaterialMaster> MaterialMaster { get; set; }
    public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    public DbSet<VendorMaster> VendorMaster { get; set; }
    public IEnumerable PurchaseOrderHeaders { get; internal set; }
    public IEnumerable MaterialMasters { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Any additional model configuration can go here
    }


}



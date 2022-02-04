using Microsoft.EntityFrameworkCore;
using AssuncaoDistribution.Models;


namespace AssuncaoDistribution.Data
{
    public class AssuncaoDistributionContext : DbContext
    {
        public AssuncaoDistributionContext (DbContextOptions<AssuncaoDistributionContext> options) : base (options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemsOrderSale> ItemsOrderSales { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Data
{
    public class AssuncaoDistributionContext : DbContext
    {
        public AssuncaoDistributionContext (DbContextOptions<AssuncaoDistributionContext> options) : base (options)
        {
        }

        DbSet<Client> Clients { get; set; }
        DbSet<ItemsOrderSale> ItemsOrderSales { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<Provider> Providers { get; set; }
        DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
        DbSet<SalesOrder> SalesOrders { get; set; }
        DbSet<UnitsMeasures> UnitsMeasures { get; set; }
    }
}

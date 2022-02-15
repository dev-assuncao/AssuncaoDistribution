using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Models;
using AssuncaoDistribution.Data;


namespace AssuncaoDistribution.Services
{
    public class SeedingService
    {
        private readonly AssuncaoDistributionContext _context;

        public SeedingService(AssuncaoDistributionContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Products.Any() || _context.Providers.Any() || _context.Clients.Any() ||
                _context.ItemsOrderSales.Any() || _context.PurchaseOrders.Any() || _context.PurchaseOrderItems.Any() ||
                _context.SalesOrders.Any())
            {
                return;
            }

            Client c1 = new Client(1, "Davisson Assunção", "Davi", new DateTime(2001, 10, 08), "Av. Presidente Castelo Branco", "09320795", "Mauá" ,"davisson.happycode@gmail.com", "11995253859", "SP", "44900552798");
            Client c2 = new Client(2, "Stephanie Souza", "Steh", new DateTime(2000, 05, 06), "Av. Barão de Mauá","09320130", "Mauá", "stephanie@gmail.com", "11985764370", "SP", "09289201920");

            Provider p1 = new Provider(001, "Papeis Alexandre LTDA", "Pampa", "10020030001", "Rua Angelo Bertuchi", "Vila Nova Mauá", "09390620", "Mauá", 980706050, 05001, "pampa.lda@gmail.com", "Pampa Papeis", 4.00);
            Provider p2 = new Provider(002, "Plasticos Moura LTDA", "Plastik", "10020030002", "Gilberto Verdoliva", "Vila Nova Mauá", "09390720", "Mauá", 980706047, 06001, "plastik.lda@gmail.com", "Plastik Moura", 9.00);

            SalesOrder s1 = new SalesOrder(001, c1,  new DateTime(2022,01,01), 50.00);
            SalesOrder s2 = new SalesOrder(002, c2, new DateTime(2022, 01, 02), 150.00);

            Products pr1 = new Products(001, "Plastic", UnitsMeasures.Kilograms, 20, 5.00);
            Products pr2 = new Products(002, "Paper", UnitsMeasures.Kilograms, 20, 10.00);

            ItemsOrderSale is1 = new ItemsOrderSale(001, 10, 50.00, s1, pr1);
            ItemsOrderSale is2 = new ItemsOrderSale(002, 15, 150.00, s2, pr2);

            PurchaseOrder po1 = new PurchaseOrder(001, p1, new DateTime(2022, 01, 10), 40.00);
            PurchaseOrder po2 = new PurchaseOrder(002, p2, new DateTime(2022, 01, 11), 90.00);

            PurchaseOrderItems pi1 = new PurchaseOrderItems(001, po1, pr1, 10, 4.00);
            PurchaseOrderItems pi2 = new PurchaseOrderItems(002, po2, pr2, 10, 9.00);

            _context.Clients.AddRange(c1, c2);
            _context.Providers.AddRange(p1, p2);
            _context.SalesOrders.AddRange(s1, s2);
            _context.Products.AddRange(pr1, pr2);
            _context.ItemsOrderSales.AddRange(is1, is2);
            _context.PurchaseOrders.AddRange(po1, po2);
            _context.PurchaseOrderItems.AddRange(pi1, pi2);

            _context.SaveChanges();

        }
    }
}

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
                _context.SalesOrders.Any() || _context.UnitsMeasures.Any())
            {
                return;
            }

            Client c1 = new Client(1, "Davisson Assunção", "Davi", new DateTime(2001, 10, 08), "Av. Presidente Castelo Branco", 09320 - 795, "Mauá" ,"davisson.happycode@gmail.com", 995253859, "SP", 44900552798);
            Client c2 = new Client(2, "Stephanie Souza", "Steh", new DateTime(2000, 05, 06), "Av. Barão de Mauá", 09320 - 130, "Mauá", "stephanie@gmail.com", 985764370, "SP", 09289201920);

            Provider p1 = new Provider(001, "Papeis Alexandre LTDA", "Pampa", 10020030005, "Rua Angelo Bertuchi", "Vila Nova Mauá", 09390 - 620, "Mauá", 980706050, 05001, "pampa.lda@gmail.com", "Pampa Papeis");




        }
    }
}

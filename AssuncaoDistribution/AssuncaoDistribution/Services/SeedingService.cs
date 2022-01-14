﻿using System;
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

            Client c1 = new Client(1, "Davisson Assunção", "Davi", new DateTime(2001,10,08), "Av. Presidente Castelo Branco", 09320 - 795, "Mauá", "davisson.happycode@gmail.com", 995253859, 44900552798);

            }
        }
    }
}

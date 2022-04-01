using System.Collections.Generic;
using System.Linq;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;
using Microsoft.EntityFrameworkCore;
using AssuncaoDistribution.Services.Exceptions;
using System;

namespace AssuncaoDistribution.Services
{
    public class PurchaseOrderServices
    {
        private readonly AssuncaoDistributionContext _purchaseOrderContext;

        public PurchaseOrderServices (AssuncaoDistributionContext context)
        {
            _purchaseOrderContext = context;
        }


        public ICollection<PurchaseOrder> AllPurchaseOrders()
        {
            return _purchaseOrderContext.PurchaseOrders.Include(obj => obj.Providers).ToList();
        }


        public void CreatePurchaseOrder(PurchaseOrder purchase)
        {
            var hasPurchase = _purchaseOrderContext.PurchaseOrders.Any(x => x.Id == purchase.Id);

            if(hasPurchase)
            {
                throw new DbConcurrencyException("Purchase Order already registered in database");
            }

            try
            {
                _purchaseOrderContext.PurchaseOrders.Add(purchase);
                _purchaseOrderContext.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}

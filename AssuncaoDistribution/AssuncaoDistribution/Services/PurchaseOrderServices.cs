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


        public PurchaseOrder FindPurchaseOrder(int id)
        {
            return _purchaseOrderContext.PurchaseOrders.Include(obj => obj.Providers).FirstOrDefault(x => x.Id == id);
        }


        public void UpdatePurchaseOrder (PurchaseOrder purchaseOrder)
        {
            var hasPurchase = _purchaseOrderContext.PurchaseOrders.Any(x => x.Id == purchaseOrder.Id);

            if (!hasPurchase)
            {
                throw new NotFoundException("Purchase not find in database");
            }

            try
            {
                _purchaseOrderContext.Update(purchaseOrder);

                _purchaseOrderContext.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }


    }
}

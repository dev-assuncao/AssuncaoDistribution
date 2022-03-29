using System.Collections.Generic;
using System.Linq;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;
using Microsoft.EntityFrameworkCore;

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



    }
}

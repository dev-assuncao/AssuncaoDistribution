using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class PurchaseOrderServices
    {
        private readonly AssuncaoDistributionContext _purchaseOrderContext;

        public PurchaseOrderServices (AssuncaoDistributionContext context)
        {
            _purchaseOrderContext = context;
        }


        public ICollection<PurchaseOrder> FindAllPurchaseOrders ()
        {
            return _purchaseOrderContext.PurchaseOrders.ToList();
        }

    }
}

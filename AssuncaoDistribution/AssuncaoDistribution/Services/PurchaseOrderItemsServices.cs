using System.Collections.Generic;
using System.Linq;
using AssuncaoDistribution.Data;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Services
{
    public class PurchaseOrderItemsServices
    {
        private readonly AssuncaoDistributionContext _purchaseItemsContext;

        public PurchaseOrderItemsServices (AssuncaoDistributionContext context)
        {
            _purchaseItemsContext = context;
        }

        public ICollection<PurchaseOrderItem> FindAllPurchaseItems()
        {
              return  _purchaseItemsContext.PurchaseOrderItems.ToList();
        }

        /*implementing yet
        public void CreatePurchaseItems()
        {

        }*/


    }
}

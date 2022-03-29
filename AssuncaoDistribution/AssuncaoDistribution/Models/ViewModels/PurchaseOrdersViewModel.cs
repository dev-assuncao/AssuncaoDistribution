using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Models.ViewModels
{
    public class PurchaseOrdersViewModel
    {
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public Provider Providers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssuncaoDistribution.Models;

namespace AssuncaoDistribution.Models.ViewModels
{
    public class PurchaseOrdersViewModel
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public ICollection<Provider> Providers { get; set; }
    }
}

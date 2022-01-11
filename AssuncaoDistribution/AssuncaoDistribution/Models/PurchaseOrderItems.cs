using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrderItems
    {
        public int CodItemsOrder { get; set; }
        public PurchaseOrder CodPurchOrder { get; set; }
        public Products CodProd { get; set; }
        public int Amount { get; set; }
        public double PriceItems { get; set; }


    }
}

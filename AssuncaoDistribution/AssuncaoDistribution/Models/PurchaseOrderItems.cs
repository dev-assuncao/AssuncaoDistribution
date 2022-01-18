using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrderItems
    {
        public int Id { get; set; }
        public PurchaseOrder PurchOrder { get; set; }
        public Products Prod { get; set; }
        public int Amount { get; set; }
        public double PriceItems { get; set; }

        [ForeignKey("PurchOrder")]
        public int PurchOrderId { get; set; }
        [ForeignKey("Prod")]
        public int ProdId { get; set; }

        public PurchaseOrderItems()
        {
        }

        public PurchaseOrderItems(int idItemsOrder, PurchaseOrder purchaseOrder, Products prod, int amount, double priceItems)
        {
            Id = idItemsOrder;
            PurchOrder = purchaseOrder;
            Prod = prod;
            Amount = amount;
            PriceItems = priceItems;
        }


    }
}

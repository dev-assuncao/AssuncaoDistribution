using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }
        public int CodPurchase { get; set; }
        public PurchaseOrder Purch { get; set; }
        public Products Prod { get; set; }
        public int Amount { get; set; }
        public double PriceItems { get; set; }

        [ForeignKey("Purch")]
        public int PurchId { get; set; }
        [ForeignKey("Prod")]
        public int ProdId { get; set; }

        public PurchaseOrderItem()
        {
        }

        public PurchaseOrderItem(int idItemsOrder, int cod, PurchaseOrder purchaseOrder, Products prod, int amount, double priceItems)
        {
            Id = idItemsOrder;
            CodPurchase = cod;
            Purch = purchaseOrder;
            Prod = prod;
            Amount = amount;
            PriceItems = priceItems;
        }


    }
}

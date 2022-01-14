using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace AssuncaoDistribution.Models
{
    public class ItemsOrderSale
    {

        public int Id { get; set; }
        public int AmountOrder { get; set; }
        public double PriceOrder { get; set; }
        public SalesOrder Sales { get; set; }
        public Products Prod { get; set; }

        [ForeignKey("Prod")]
        public int ProdId { get; set; }
        [ForeignKey("Sales")]
        public int SalesId { get; set; }

        public ItemsOrderSale()
        {
        }

        public ItemsOrderSale(int idItemSale, int amountOrder, double priceOrder)
        {
            Id = idItemSale;
            AmountOrder = amountOrder;
            PriceOrder = priceOrder;
        }
    }
}

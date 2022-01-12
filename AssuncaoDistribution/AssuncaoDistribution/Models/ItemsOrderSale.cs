using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class ItemsOrderSale
    {

        public int CodItemSale { get; set; }
        public SalesOrder CodOrderSale { get; set; }
        public Products CodProd { get; set; }
        public int AmountOrder { get; set; }
        public double PriceOrder { get; set; }

        public ItemsOrderSale (int codItemSale, SalesOrder codOrderSale, Products codProd, int amount, double price)
        {
            CodItemSale = codItemSale;
            CodOrderSale = codOrderSale;
            CodProd = codProd;
            AmountOrder = amount;
            PriceOrder = price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrder
    {
        public int CodPurch { get; set; }
        public Provider CodPvd { get; set; }
        public DateTime PurchDate { get; set; }
        public double PriceOrder { get; set; }

        public PurchaseOrder(int codPurch, Provider codPvd, DateTime purchDate, double priceOrder)
        {
            CodPurch = codPurch;
            CodPvd = codPvd;
            PurchDate = purchDate;
            PriceOrder = priceOrder;
        }
    }
}

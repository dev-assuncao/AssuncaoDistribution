using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public Provider Providers { get; set; }
        public DateTime PurchDate { get; set; }
        public double PriceOrder { get; set; }

        [ForeignKey("Providers")]
        public int ProviderId { get; set; }


        public PurchaseOrder()
        {
        }

        public PurchaseOrder(int codPurch, Provider codPvd, DateTime purchDate, double priceOrder)
        {
            Id = codPurch;
            Providers = codPvd;
            PurchDate = purchDate;
            PriceOrder = priceOrder;
        }
    }
}

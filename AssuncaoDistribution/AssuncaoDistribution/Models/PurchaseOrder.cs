using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public Provider Providers { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Purch Date")]
        public DateTime PurchDate { get; set; }

        [DisplayFormat(DataFormatString = "R${0:F2}")]

        [Display(Name ="Price Order")]
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

        public double PricePerOrder(int amount)
        {
            return amount * PriceOrder; 
        }
    }
}

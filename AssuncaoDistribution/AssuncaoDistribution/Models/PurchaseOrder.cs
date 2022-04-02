using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AssuncaoDistribution.Models
{
    public class PurchaseOrder
    {

        [ReadOnly(true)]
        public int Id { get; set; }
        public Provider Providers { get; set; }

        [Display(Name = "Purch Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime PurchDate { get; set; }

        [DisplayFormat(DataFormatString = "R${0:F2}")]

        [Display(Name = "Price Order")]
        public double PriceOrder { get; set; }

        [ForeignKey("Providers")]
        [Display(Name ="Provider")]
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
